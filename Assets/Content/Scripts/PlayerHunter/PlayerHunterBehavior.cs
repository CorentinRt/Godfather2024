using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHunterBehavior : MonoBehaviour
{
    [Header("Get Input (Do not touch !!!!)")]

    [SerializeField] private InputActionReference _mouseRotationHunter;

    [SerializeField] private float _speed;

    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _rotationDeceleration;

    private Rigidbody2D _rb2D;


    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _mouseRotationHunter.action.performed += UpdateRotation;
    }
    private void OnDestroy()
    {
        _mouseRotationHunter.action.performed -= UpdateRotation;
    }
    private void FixedUpdate()
    {
        DecelerateRotation();

        HunterMove();
    }

    private void UpdateRotation(InputAction.CallbackContext context)
    {
        Vector2 tempVect = context.ReadValue<Vector2>();

        _rb2D.angularVelocity += tempVect.x * Time.deltaTime * _rotationSpeed;
    }

    private void HunterMove()
    {
        _rb2D.velocity = transform.up * Time.deltaTime * _speed;
    }

    private void DecelerateRotation()
    {
        if (Mathf.Abs(_rb2D.angularVelocity) > 1f)
        {
            _rb2D.angularVelocity = Mathf.Lerp(_rb2D.angularVelocity, 0f, Time.deltaTime * _rotationDeceleration);
        }
        else
        {
            _rb2D.angularVelocity = 0f;
        }
    }
}
