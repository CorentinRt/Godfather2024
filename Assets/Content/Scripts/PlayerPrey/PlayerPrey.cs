using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerPrey : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] InputActionReference _moveInput;

    private bool _isDead;

    private GameManager _gameManager;

    public bool IsDead { get => _isDead; set => _isDead = value; }

    public event Action OnPreyDie;

    private void Start()
    {
        _gameManager = GameManager.Instance;

        if (_gameManager == null)
        {
            Debug.LogWarning("GameManager Missing ! Victory detection won't work !!!");
        }
    }
    private void Update() {

        if (_isDead)
            return;

        Vector2 tempvect = _moveInput.action.ReadValue<Vector2>();

        if (tempvect.magnitude > 1){
            tempvect.Normalize();
        }

        transform.position += new Vector3(tempvect.x, tempvect.y) * Time.deltaTime * _speed;
    }

    private void OnEnable() {
        _moveInput.action.Enable();
    }

    private void OnDisable()
    {
        _moveInput.action.Disable();
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
