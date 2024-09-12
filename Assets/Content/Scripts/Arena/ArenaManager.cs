using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    private static ArenaManager _instance;


    public event Action _onCollisionHunter;

    public static ArenaManager Instance { get => _instance; set => _instance = value; }


    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Two ArenaManager singleton conflicted ! One has been destroyed !");
            Destroy(gameObject);
        }

        _instance = this;
    }

    public void CallCollisionHunter()
    {
        _onCollisionHunter?.Invoke();
    }
}
