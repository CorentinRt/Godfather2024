using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPrey_Stats", menuName = "ScriptableObjects/PlayerPrey_Stats", order = 1)]
public class PlayerPrey_Stats_SC : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed { get => _speed; set => _speed = value; }
}
