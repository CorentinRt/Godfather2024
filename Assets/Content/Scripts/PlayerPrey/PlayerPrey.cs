using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerPrey : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] InputActionReference _moveInput;


    private void Update() {

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
}
