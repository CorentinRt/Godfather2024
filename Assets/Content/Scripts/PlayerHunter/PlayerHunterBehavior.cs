using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHunterBehavior : MonoBehaviour
{
    [Header("Get Input (Do not touch !!!!)")]

    [SerializeField] private InputActionReference _mouseRotationHunter;

    [SerializeField] private float _maxSpeed;

    private float _speed;
    private float _speedLerpPerc;
    [SerializeField] private float _startAccelerationSpeed;

    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _rotationDeceleration;

    [SerializeField] private float _bounceForce;
    private bool _isBounced;
    private Coroutine _bounceCooldownCoroutine;
    [SerializeField] private float _bounceTime;

    private Rigidbody2D _rb2D;

    private Coroutine _accelerateToMaxSpeedCoroutine;

    private Tweener _cameraShakeTween;

    [SerializeField] private float _cameraShakeTime;
    [SerializeField] private float _cameraShakeForce;



    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _mouseRotationHunter.action.performed += UpdateRotation;

        StartAccelerateToMaxSpeed();
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

    #region Move


    private void UpdateRotation(InputAction.CallbackContext context)
    {
        Vector2 tempVect = context.ReadValue<Vector2>();

        _rb2D.angularVelocity += tempVect.x * Time.deltaTime * _rotationSpeed;
    }

    private void HunterMove()
    {
        if (!_isBounced)
        {
            _rb2D.velocity = transform.up * Time.deltaTime * _speed;
        }
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
    #endregion

    private void Bounce(Vector2 dir)
    {
        if (_rb2D == null)
            return;

        if (_cameraShakeTween != null)
        {
            _cameraShakeTween.Complete();
        }

        _cameraShakeTween = Camera.main.DOShakePosition(_cameraShakeTime, _cameraShakeForce);

        _isBounced = true;
        StartBounceCooldown();
        _rb2D.AddForce(dir * _bounceForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                if (collision.contactCount == 0)
                    return;

                Vector2 tempVect = new Vector2(transform.position.x, transform.position.y) - collision.contacts[0].point;

                tempVect.Normalize();

                StartAccelerateToMaxSpeed();

                Bounce(tempVect);
            }
        }
    }
    private void StartBounceCooldown()
    {
        StopBounceCooldown();

        _bounceCooldownCoroutine = StartCoroutine(BounceCooldownCoroutine());
    }
    private void StopBounceCooldown()
    {
        if (_bounceCooldownCoroutine != null)
        {
            StopCoroutine(_bounceCooldownCoroutine);

            _bounceCooldownCoroutine = null;
        }
    }
    private IEnumerator BounceCooldownCoroutine()
    {
        float timer = _bounceTime;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;

            yield return null;
        }

        _isBounced = false;

        StopBounceCooldown();

        yield return null;
    }


    [Button] private void StartAccelerateToMaxSpeed()
    {
        StopAccelerationToMaxSpeed();

        _speedLerpPerc = 0;

        _speed = 0;

        _accelerateToMaxSpeedCoroutine = StartCoroutine(AccelerateToMaxSpeedCoroutine());
    }
    private void StopAccelerationToMaxSpeed()
    {
        if (_accelerateToMaxSpeedCoroutine != null)
        {
            StopCoroutine(_accelerateToMaxSpeedCoroutine);

            _accelerateToMaxSpeedCoroutine = null;
        }
    }
    private IEnumerator AccelerateToMaxSpeedCoroutine()
    {
        while (_speedLerpPerc <= 1f)
        {
            _speed = Mathf.Lerp(_speed, _maxSpeed, _speedLerpPerc);

            _speedLerpPerc += Time.deltaTime * _startAccelerationSpeed;

            yield return null;
        }

        yield return null;
    }
}
