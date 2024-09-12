using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PhaseManager : MonoBehaviour
{
    private static PhaseManager _instance;
    public enum Phases {PreGame, InGame, PostGame};
    private Phases _currentPhase;

    [SerializeField]
    private float _cooldownDuration;
    [SerializeField]
    private float _victoryScreenDuration;

    [SerializeField] private PlayerInput _hunterInput;
    [SerializeField] private PlayerInput _preyInput;


    public PlayerHunterBehavior IronBehavior;
    public HunterLineBehavior LineBehavior;

    public GameObject Hunter;
    public GameObject Prey;

    [SerializeField]
    private float _spawnPoint;

    public TextMeshProUGUI CountDownText;
    public RectTransform CountDownRectTransform;

    [SerializeField] private Countdown _countDownScript;

    private GameManager GM;


    public event Action<Phases> _onPhasesChanged;
    public event Action _onGameStarted;
    public event Action _onCountDownStart;
    
    #region Properties
    public static PhaseManager Instance { get => _instance; set => _instance = value; }

    #endregion

    #region Singleton Setup
    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Two PhaseManager singleton conflicted ! One has been destroyed !");
        }
        _instance = this;
    }
    #endregion

    void Start()
    {
        GM = GameManager.Instance;
        if(GM!= null)
        {
            GM._onWin += Win;
        }
        DOTween.Init();
        RoundStart();
    }

    void OnDestroy()
    {
        if (GM != null)
        {
            GM._onWin -= Win;
        }
    }

    private void ChangeCurrentPhase(Phases phase)
    {
        _currentPhase = phase;
        _onPhasesChanged?.Invoke(phase);
        if (_currentPhase == Phases.InGame)
        {
            _onGameStarted?.Invoke();
        }
        if (_currentPhase == Phases.PreGame)
        {
            _onCountDownStart?.Invoke();
        }
    }

    void RoundStart()
    {
        ChangeCurrentPhase(Phases.PreGame);

        //reset timer
        //_countDownScript.TimeLeft = 60;
        // disable inputs
        IronBehavior.enabled = false;
        LineBehavior.enabled = false;
        _hunterInput.actions.FindAction("MouseRotationHunter").Disable();
        _preyInput.actions.FindAction("MovePrey").Disable();
        // teleport Players
        Hunter.transform.position = new Vector3(-_spawnPoint, 0, 0);
        Prey.transform.position = new Vector3(_spawnPoint, 0, 0);

        // countdown animation
        StartCoroutine(CountDownAnimation());
    }

    void endOfCooldown()
    {
        ChangeCurrentPhase(Phases.InGame);
        
        // enable inputs
        _hunterInput.actions.FindAction("MouseRotationHunter").Enable();
        _preyInput.actions.FindAction("MovePrey").Enable();
        IronBehavior.enabled = true;
        LineBehavior.enabled = true;
        // start timer
        _countDownScript.LaunchTimer();
    }

    

    IEnumerator CountDownAnimation()
    {
        CountDownText.text = "READY ?";
        yield return new WaitForSeconds(1.5f);
        CountDownRectTransform.DOShakeAnchorPos(0.4f, 20, 100);
        CountDownText.text = "3";
        yield return new WaitForSeconds(0.5f);
        CountDownRectTransform.DOShakeAnchorPos(0.4f, 20, 100);
        CountDownText.text = "2";
        yield return new WaitForSeconds(0.5f);
        CountDownRectTransform.DOShakeAnchorPos(0.4f, 20, 100);
        CountDownText.text = "1";
        yield return new WaitForSeconds(0.5f);
        CountDownRectTransform.DOShakeAnchorPos(0.4f, 20, 100);
        CountDownText.text = "GO";
        endOfCooldown();
        yield return new WaitForSeconds(0.5f);
        CountDownText.DOFade(0, 0.2f);
        yield return new WaitForSeconds(1);
        CountDownText.enabled = false;

    }

    void Win()
    {
        ChangeCurrentPhase(Phases.PostGame);
        // animation ?
    }
}
