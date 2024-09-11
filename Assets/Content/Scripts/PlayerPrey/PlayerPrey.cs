using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerPrey : MonoBehaviour
{
    #region Fields
    [SerializeField] InputActionReference _moveInput;


    [SerializeField] private float _speed;

    private Rigidbody2D _rb2D;

    private bool _isDead;

    private bool _canMove;

    private GameManager _gameManager;
    private PhaseManager _phaseManager;
    private Coroutine _decelerationCoroutine;

    #endregion

    public bool IsDead { get => _isDead; set => _isDead = value; }

    public event Action OnPreyDie;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _gameManager = GameManager.Instance;

        _phaseManager = PhaseManager.Instance;

        _moveInput.action.started += StartMove;
        _moveInput.action.performed += UpdateMove;
        _moveInput.action.canceled += StopMove;

        if (_gameManager == null)
        {
            Debug.LogWarning("GameManager Missing ! Victory detection won't work !!!");
        }
        if (_phaseManager != null)
        {
            _phaseManager._onPhasesChanged += ChangeMoveState;
        }
        else
        {
            Debug.LogWarning("PhaseManager Missing ! Specific actions during phases won't work !!!");
        }
    }

    private void OnDestroy()
    {
        _moveInput.action.started -= StartMove;
        _moveInput.action.performed -= UpdateMove;
        _moveInput.action.canceled -= StopMove;

        if (_phaseManager != null)
        {
            _phaseManager._onPhasesChanged -= ChangeMoveState;
        }
    }

    private void OnEnable() {
        _moveInput.action.Enable();
    }

    private void OnDisable()
    {
        _moveInput.action.Disable();
    }

    private void ChangeMoveState(PhaseManager.Phases phase)
    {
        switch (phase)
        {
            case PhaseManager.Phases.PreGame:
                _canMove = false;
                break;

            case PhaseManager.Phases.InGame:
                _canMove = true;
                break;

            case PhaseManager.Phases.PostGame:
                _canMove = false;
                break;
        }
    }
    private void StartMove(InputAction.CallbackContext context)
    {
        if (_rb2D == null)
            return;

        if (_isDead || !_canMove)
        {
            _rb2D.velocity = Vector2.zero;
            return;
        }

        Vector2 dir = context.ReadValue<Vector2>();

        dir.Normalize();

        _rb2D.velocity = dir * _speed;
    }
    private void UpdateMove(InputAction.CallbackContext context)
    {
        if (_rb2D == null)
            return;

        if (_isDead || !_canMove)
        {
            _rb2D.velocity = Vector2.zero;
            return;
        }

        Vector2 dir = context.ReadValue<Vector2>();

        dir.Normalize();

        _rb2D.velocity = dir * _speed;
    }
    private void StopMove(InputAction.CallbackContext context)
    {
        if (_rb2D == null)
            return;

        _rb2D.velocity = Vector2.zero;
    }

    public void Die()
    {
        if (_isDead)
            return;

        Debug.Log("Prey Die");
        _isDead = true;
        OnPreyDie?.Invoke();

        if (_gameManager != null)
        {
            _gameManager.HunterWins();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDead)
            return;

        if (collision != null)
        {
            if (collision.gameObject.CompareTag("PlayerHunter"))
            {
                Die();
            }
        }
    }
}
