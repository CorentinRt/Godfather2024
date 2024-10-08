using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    // passage en public pour reprendre la valeur
    public enum WINNER_TYPE
    {
        NONE,
        HUNTER,
        PREY
    }

    // Creation d'un get
    public WINNER_TYPE WinnerType { get => _winnerType; }

    private static GameManager _instance;

    public PlayerPrey preyScript;
    public Countdown clockScript;

    public GameObject preyPlayer;
    public GameObject hunterPlayer;

    private WINNER_TYPE _winnerType;

    public event Action _onWin;
    public event Action _onWPreyin;
    public event Action _onHunterWin;
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
        Debug.Log("Le chasseur � gagn�");

        _onHunterWin?.Invoke();
        OnHunterWinsUnity?.Invoke();
        Win();
    }

    public void PreyWins()
    {
        if (_winnerType != WINNER_TYPE.NONE)
            return;

        _winnerType = WINNER_TYPE.PREY;
        Debug.Log("La proie � gagn�");

        _onWPreyin?.Invoke();
        OnPreyWinsUnity?.Invoke();

        Win();
    }

    private void Win()
    {
        _onWin?.Invoke();
        OnWinUnity?.Invoke();
    }
}
