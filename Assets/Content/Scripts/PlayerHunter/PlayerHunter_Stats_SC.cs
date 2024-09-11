using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHunter_Stats", menuName = "ScriptableObjects/PlayerHunter_Stats", order = 1)]

public class PlayerHunter_Stats_SC : ScriptableObject
{
    #region Fields
    [Header("Movements")]
    [SerializeField] private float _maxSpeed;

    [SerializeField] private float _startAccelerationSpeed;

    [Header("Rotation")]
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _rotationDeceleration;

    [Header("Bounce")]
    [SerializeField] private float _bounceForce;

    [SerializeField] private float _bounceTime;

    [Header("Shake")]
    [SerializeField] private float _cameraShakeTime;
    [SerializeField] private float _cameraShakeForce;


    #endregion

    #region Properties
    public float MaxSpeed { get => _maxSpeed; set => _maxSpeed = value; }
    public float StartAccelerationSpeed { get => _startAccelerationSpeed; set => _startAccelerationSpeed = value; }
    public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }
    public float RotationDeceleration { get => _rotationDeceleration; set => _rotationDeceleration = value; }
    public float BounceForce { get => _bounceForce; set => _bounceForce = value; }
    public float BounceTime { get => _bounceTime; set => _bounceTime = value; }
    public float CameraShakeTime { get => _cameraShakeTime; set => _cameraShakeTime = value; }
    public float CameraShakeForce { get => _cameraShakeForce; set => _cameraShakeForce = value; }

    #endregion

}
