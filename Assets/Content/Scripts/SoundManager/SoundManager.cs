using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    private AudioSource _audioSource;

    [SerializeField] private SoundList_SC _soundList;

    private Coroutine _loopInsultesCoroutine;
    private Coroutine _loopVapeurCoroutine;

    private GameManager _gameManager;
    private PhaseManager _phaseManager;

    public static SoundManager Instance { get => _instance; set => _instance = value; }

    private void Awake()
    {
        #region Singleton setup
        if ( _instance != null)
        {
            Debug.LogWarning("Two SoundManager singleton conflicted ! One has been destroyed !");
            Destroy(gameObject);
        }
        _instance = this;
        #endregion

        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _gameManager = GameManager.Instance;

        _phaseManager = PhaseManager.Instance;

        if (_gameManager != null)
        {
            _gameManager._onWPreyin += PlayDeceptionVoiceline;
            _gameManager._onHunterWin += PlaySouffranceVoiceline;
        }

        if (_phaseManager != null)
        {
            _phaseManager._onGameStarted += StartLoopInsultes;
            _phaseManager._onGameStarted += PlayMusic;
            _phaseManager._onCountDownStart += PlayCountdownSFX;

            _phaseManager._onGameStarted += StartLoopVapeur;
        }
    }
    private void OnDestroy()
    {
        if (_gameManager != null)
        {
            _gameManager._onWPreyin -= PlayDeceptionVoiceline;
            _gameManager._onHunterWin -= PlaySouffranceVoiceline;
        }

        if (_phaseManager != null)
        {
            _phaseManager._onGameStarted -= StartLoopInsultes;
            _phaseManager._onGameStarted -= PlayMusic;
            _phaseManager._onCountDownStart -= PlayCountdownSFX;

            _phaseManager._onGameStarted -= StartLoopVapeur;
        }
    }

    #region Voicelines
    public void PlaySouffranceVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.SouffranceVoiceline);
    }
    public void PlayDeceptionVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.DeceptionVoiceline);
    }
    public void PlayVetementsTombentVoiceline()
    {
        int rand = Random.Range(0, _soundList.VetementsTombentVoiceline.Count - 1);

        _audioSource.PlayOneShot(_soundList.VetementsTombentVoiceline[rand]);
    }
    #endregion

    #region Insultes
    #region Loop Insultes
    public void StartLoopInsultes()
    {
        Debug.Log("Play random insultes");
        _loopInsultesCoroutine = StartCoroutine(LoopInsultesCoroutine());
    }
    private IEnumerator LoopInsultesCoroutine()
    {
        float timeRemain = _soundList.TimeBetweenInsultes;

        if (timeRemain != 0)
        {
            while (true)
            {
                if (timeRemain <= 0f)
                {
                    StartLoopInsultes();
                    timeRemain = _soundList.TimeBetweenInsultes;
                }
                else
                {
                    timeRemain -= Time.deltaTime;
                }

                yield return null;
            }
        }

        yield return null;
    }
    #endregion

    public void PlayRandomInsultes()
    {
        int rand = Random.Range(0, _soundList.Insultes.Count - 1);

        _audioSource.PlayOneShot(_soundList.Insultes[rand]);
    }


    public void PlayBrulezLeVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.BrulezLeVoiceline);
    }
    public void PlayRepasseLeVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.RepasseLeVoiceline);
    }
    public void PlayOUAISVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.OUAISVoiceline);
    }
    public void PlayArracheCouturesVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.ArracheCouturesVoiceline);
    }
    public void PlayLaveJavelVoiceline()
    {
        int rand = Random.Range(0, _soundList.LaveJavelVoiceline.Count - 1);

        _audioSource.PlayOneShot(_soundList.LaveJavelVoiceline[rand]);
    }
    public void PlayChiffoneLeVoiceline()
    {
        int rand = Random.Range(0, _soundList.ChiffoneLeVoiceline.Count - 1);

        _audioSource.PlayOneShot(_soundList.ChiffoneLeVoiceline[rand]);
    }
    public void PlayAuFeuVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.AuFeuVoiceline);
    }
    public void PlayAMortVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.AMortVoiceline);
    }
    public void PlaySaleVetementVoiceline()
    {
        int rand = Random.Range(0, _soundList.SaleVetementVoiceline.Count - 1);

        _audioSource.PlayOneShot(_soundList.SaleVetementVoiceline[rand]);
    }
    public void PlayDeffripeLeVoiceline()
    {
        int rand = Random.Range(0, _soundList.DeffripeLeVoiceline.Count - 1);

        _audioSource.PlayOneShot(_soundList.DeffripeLeVoiceline[rand]);
    }
    public void PlayTransformeChiffonVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.TransformeChiffonVoiceline);
    }
    public void PlayVaTeFerVoiceline()
    {
        int rand = Random.Range(0, _soundList.VaTeFerVoiceline.Count - 1);

        _audioSource.PlayOneShot(_soundList.VaTeFerVoiceline[rand]);
    }
    public void PlayLeCombatPlieVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.LeCombatPlieVoiceline);
    }
    public void PlayTesVraimentMancheVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.TesVraimentMancheVoiceline);
    }
    public void PlayBouffeLuiLesCouturesVoiceline()
    {
        int rand = Random.Range(0, _soundList.BouffeLuiLesCouturesVoiceline.Count - 1);

        _audioSource.PlayOneShot(_soundList.BouffeLuiLesCouturesVoiceline[rand]);
    }
    public void PlayVaTeFerRavalerVoiceline()
    {
        _audioSource.PlayOneShot(_soundList.VaTeFerRavalerVoiceline);
    }
    public void PlayDecoudsLuiPochesVoiceline()
    {
        int rand = Random.Range(0, _soundList.DecoudsLuiPochesVoiceline.Count - 1);

        _audioSource.PlayOneShot(_soundList.DecoudsLuiPochesVoiceline[rand]);
    }
    #endregion

    #region SFX
    public void PlayMoteurSFX() // Played directly on gameObject Hunter
    {
        _audioSource.PlayOneShot(_soundList.MoteurSFX);
    }
    #region Vapeur
    public void PlayVapeurSFX()
    {
        Debug.Log("Play vapeur sound");

        int rand = Random.Range(0, _soundList.VapeurSFX.Count - 1);

        _audioSource.PlayOneShot(_soundList.VapeurSFX[rand]);
    }
    private void StartLoopVapeur()
    {
        if (_soundList.TimeBetweenVapeur == 0f)
            return;

        _loopVapeurCoroutine = StartCoroutine(LoopVapeurCoroutine());
    }
    private IEnumerator LoopVapeurCoroutine()
    {
        float vapeurTimer = _soundList.TimeBetweenVapeur;

        while (true)
        {
            if (vapeurTimer <= 0f)
            {
                PlayVapeurSFX();
                vapeurTimer = _soundList.TimeBetweenVapeur;
            }
            else
            {
                vapeurTimer -= Time.deltaTime;
            }

            yield return null;
        }
    }
    #endregion

    public void PlayCollisionWallSFX()
    {
        int rand = Random.Range(0, _soundList.CollisionWallSFX.Count - 1);

        _audioSource.PlayOneShot(_soundList.CollisionWallSFX[rand], 0.2f);
    }
    public void PlayBrulureSFX()
    {
        _audioSource.PlayOneShot(_soundList.BrulureSFX);
    }
    public void PlayButtonClicSFX()
    {
        _audioSource.PlayOneShot(_soundList.ButtonClicSFX);
    }
    public void PlayCountdownSFX()
    {
        _audioSource.PlayOneShot(_soundList.CountdownSFX);
    }
    #endregion

    #region Musics
    public void PlayMusic()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "MainMenu":
                PlayMenuMusic();
                break;

            case "MainGame":
                PlayArenaMusic();
                break;

            case "Credit":
                PlayCreditMusic();
                break;
        }
    }

    private void PlayMenuMusic()
    {
        _audioSource.PlayOneShot(_soundList.MenuMusic);
    }
    private void PlayArenaMusic()
    {
        _audioSource.PlayOneShot(_soundList.ArenaMusic);
    }
    private void PlayCreditMusic()
    {
        _audioSource.PlayOneShot(_soundList.CreditMusic);
    }
    #endregion
}
