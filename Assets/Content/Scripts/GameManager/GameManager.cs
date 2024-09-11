using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private enum WINNER_TYPE
    {
        NONE,
        HUNTER,
        PREY
    }


    private static GameManager _instance;

    public PlayerPrey preyScript;
    public Countdown clockScript;

    public GameObject preyPlayer;
    public GameObject hunterPlayer;

    private WINNER_TYPE _winnerType;

    public event Action _onWin;
    public UnityEvent OnWinUnity;
    public UnityEvent OnPreyWinsUnity;
    public UnityEvent OnHunterWinsUnity;

    public static GameManager Instance { get => _instance; set => _instance = value; }


    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Two GameManager singleton conflicted ! One has been destroyed !");
            Destroy(gameObject);
        }

        _instance = this;
    }

    public void HunterWins()
    {
        if (_winnerType != WINNER_TYPE.NONE)
            return;

        _winnerType = WINNER_TYPE.HUNTER;
        Debug.Log("Le chasseur à gagné");

        OnHunterWinsUnity?.Invoke();
        Win();
    }

    public void PreyWins()
    {
        if (_winnerType != WINNER_TYPE.NONE)
            return;

        _winnerType = WINNER_TYPE.PREY;
        Debug.Log("La proie à gagné");

        OnPreyWinsUnity?.Invoke();

        Win();
    }

    private void Win()
    {
        _onWin?.Invoke();
        OnWinUnity?.Invoke();
    }
}
