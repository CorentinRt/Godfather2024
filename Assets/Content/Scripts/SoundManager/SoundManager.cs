using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    [SerializeField] private AudioSource _audioSourceSFX;
    [SerializeField] private AudioSource _audioSourceVocals;
    [SerializeField] private AudioSource _audioSourceMusics;
    [SerializeField] private AudioMixer _audioMixer;


    [SerializeField] private SoundList_SC _soundList;
    [SerializeField] private Animator _HunterSteamAnimator;

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
    }
    private void Start()
    {
        _gameManager = GameManager.Instance;

        _phaseManager = PhaseManager.Instance;

        SetMasterVolume(_soundList.MasterVolume);
        SetSFXVolume(_soundList.SfxVolume);
        SetVocalsVolume(_soundList.VocalsVolume);
        SetMusicVolume(_soundList.MusicVolume);

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

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayMenuMusic();
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

    #region Mixer
    public void SetMasterVolume(float volume)
    {
        _audioMixer.SetFloat("MasterVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        _audioMixer.SetFloat("SFXVolume", volume);
    }
    public void SetVocalsVolume(float volume)
    {
        _audioMixer.SetFloat("VocalsVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat("MusicVolume", volume);
    }



    #endregion

    #region Voicelines
    public void PlaySouffranceVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.SouffranceVoiceline);
    }
    public void PlayDeceptionVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.DeceptionVoiceline);
    }
    public void PlayVetementsTombentVoiceline()
    {
        int rand = Random.Range(0, _soundList.VetementsTombentVoiceline.Count - 1);

        _audioSourceVocals.PlayOneShot(_soundList.VetementsTombentVoiceline[rand]);
    }
    #endregion

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
                    PlayRandomInsultes();
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

    #region Insultes
    public void PlayRandomInsultes()
    {
        int rand = Random.Range(0, _soundList.Insultes.Count - 1);

        _audioSourceVocals.PlayOneShot(_soundList.Insultes[rand]);
    }


    public void PlayBrulezLeVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.BrulezLeVoiceline);
    }
    public void PlayRepasseLeVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.RepasseLeVoiceline);
    }
    public void PlayOUAISVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.OUAISVoiceline);
    }
    public void PlayArracheCouturesVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.ArracheCouturesVoiceline);
    }
    public void PlayLaveJavelVoiceline()
    {
        int rand = Random.Range(0, _soundList.LaveJavelVoiceline.Count - 1);

        _audioSourceVocals.PlayOneShot(_soundList.LaveJavelVoiceline[rand]);
    }
    public void PlayChiffoneLeVoiceline()
    {
        int rand = Random.Range(0, _soundList.ChiffoneLeVoiceline.Count - 1);

        _audioSourceVocals.PlayOneShot(_soundList.ChiffoneLeVoiceline[rand]);
    }
    public void PlayAuFeuVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.AuFeuVoiceline);
    }
    public void PlayAMortVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.AMortVoiceline);
    }
    public void PlaySaleVetementVoiceline()
    {
        int rand = Random.Range(0, _soundList.SaleVetementVoiceline.Count - 1);

        _audioSourceVocals.PlayOneShot(_soundList.SaleVetementVoiceline[rand]);
    }
    public void PlayDeffripeLeVoiceline()
    {
        int rand = Random.Range(0, _soundList.DeffripeLeVoiceline.Count - 1);

        _audioSourceVocals.PlayOneShot(_soundList.DeffripeLeVoiceline[rand]);
    }
    public void PlayTransformeChiffonVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.TransformeChiffonVoiceline);
    }
    public void PlayVaTeFerVoiceline()
    {
        int rand = Random.Range(0, _soundList.VaTeFerVoiceline.Count - 1);

        _audioSourceVocals.PlayOneShot(_soundList.VaTeFerVoiceline[rand]);
    }
    public void PlayLeCombatPlieVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.LeCombatPlieVoiceline);
    }
    public void PlayTesVraimentMancheVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.TesVraimentMancheVoiceline);
    }
    public void PlayBouffeLuiLesCouturesVoiceline()
    {
        int rand = Random.Range(0, _soundList.BouffeLuiLesCouturesVoiceline.Count - 1);

        _audioSourceVocals.PlayOneShot(_soundList.BouffeLuiLesCouturesVoiceline[rand]);
    }
    public void PlayVaTeFerRavalerVoiceline()
    {
        _audioSourceVocals.PlayOneShot(_soundList.VaTeFerRavalerVoiceline);
    }
    public void PlayDecoudsLuiPochesVoiceline()
    {
        int rand = Random.Range(0, _soundList.DecoudsLuiPochesVoiceline.Count - 1);

        _audioSourceVocals.PlayOneShot(_soundList.DecoudsLuiPochesVoiceline[rand]);
    }
    #endregion

    #region SFX
    public void PlayMoteurSFX() // Played directly on gameObject Hunter
    {
        _audioSourceSFX.PlayOneShot(_soundList.MoteurSFX);
    }
    #region Vapeur
    public void PlayVapeurSFX()
    {
        Debug.Log("Play vapeur sound");

        if (_HunterSteamAnimator != null)
            _HunterSteamAnimator.SetTrigger("SteamAnimation");

        int rand = Random.Range(0, _soundList.VapeurSFX.Count - 1);

        _audioSourceSFX.PlayOneShot(_soundList.VapeurSFX[rand]);
    }
    private void StartLoopVapeur()
    {
        if (_soundList.TimeBetweenVapeur == 0f)
            return;

        _loopVapeurCoroutine = StartCoroutine(LoopVapeurCoroutine());
    }
    private IEnumerator LoopVapeurCoroutine()
    {
        yield return null;

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

        _audioSourceSFX.PlayOneShot(_soundList.CollisionWallSFX[rand], 0.2f);
    }
    public void PlayBrulureSFX()
    {
        _audioSourceSFX.PlayOneShot(_soundList.BrulureSFX);
    }
    public void PlayButtonClicSFX()
    {
        _audioSourceSFX.PlayOneShot(_soundList.ButtonClicSFX);
    }
    public void PlayCountdownSFX()
    {
        _audioSourceSFX.PlayOneShot(_soundList.CountdownSFX);
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
        _audioSourceMusics.clip = _soundList.MenuMusic;
        _audioSourceMusics.loop = true;
        _audioSourceMusics.Play();
    }
    private void PlayArenaMusic()
    {
        _audioSourceMusics.clip = _soundList.ArenaMusic;
        _audioSourceMusics.loop = true;
        _audioSourceMusics.Play();
    }
    private void PlayCreditMusic()
    {
        _audioSourceMusics.clip = _soundList.CreditMusic;
        _audioSourceMusics.loop = true;
        _audioSourceMusics.Play();
    }
    #endregion
}
