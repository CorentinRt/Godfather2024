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


    [SerializeField] private PlayerPrey_Stats_SC _playerPreyStats;

    private Rigidbody2D _rb2D;

    private bool _isDead;

    private bool _canMove;
    private Coroutine _decelerationCoroutine;

    private GameManager _gameManager;
    private PhaseManager _phaseManager;
    private SoundManager _soundManager;

    #endregion

    public bool IsDead { get => _isDead; set => _isDead = value; }

    public event Action _onPreyDie;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _gameManager = GameManager.Instance;

        _phaseManager = PhaseManager.Instance;

        _soundManager = SoundManager.Instance;

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

        _rb2D.velocity = dir * _playerPreyStats.Speed;

        this.transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("PyjRun", true);
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

        _rb2D.velocity = dir * _playerPreyStats.Speed;
    }
    private void StopMove(InputAction.CallbackContext context)
    {
        if (_rb2D == null)
            return;

        _rb2D.velocity = Vector2.zero;

        this.transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetBool("PyjRun", false);
    }

    public void Die()
    {
        if (_isDead)
            return;

        Debug.Log("Prey Die");
        _isDead = true;
        _onPreyDie?.Invoke();

        if (_soundManager != null)
        {
            _soundManager.PlayBrulureSFX();
        }

        if (_gameManager != null)
        {
            _gameManager.HunterWins();
        }

        this.transform.GetChild(0).GetChild(0).GetComponent<Animator>().SetTrigger("PyjamaDies");
        this.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
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
