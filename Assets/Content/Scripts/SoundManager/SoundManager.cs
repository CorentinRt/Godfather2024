using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    private AudioSource _audioSource;

    [SerializeField] private SoundList_SC _soundList;


    private GameManager _gameManager;

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

        if (_gameManager != null)
        {
            _gameManager._onWPreyin += PlayDeceptionVoiceline;
            _gameManager._onHunterWin += PlaySouffranceVoiceline;
        }
    }
    private void OnDestroy()
    {
        if (_gameManager != null)
        {
            _gameManager._onWPreyin -= PlayDeceptionVoiceline;
            _gameManager._onHunterWin -= PlaySouffranceVoiceline;
        }
    }

    #region Voicelines
    public void PlaySouffranceVoiceline()
    {

    }
    public void PlayDeceptionVoiceline()
    {

    }
    public void PlayVetementsTombentVoiceline()
    {

    }
    public void PlayInsultesVoiceline()
    {

    }
    public void PlayBrulezLeVoiceline()
    {

    }
    public void PlayRepasseLeVoiceline()
    {

    }
    public void PlayOUAISVoiceline()
    {

    }
    public void PlayArracheCouturesVoiceline()
    {

    }
    public void PlayLaveJavelVoiceline()
    {

    }
    public void PlayChiffoneLeVoiceline()
    {

    }
    public void PlayAuFeuVoiceline()
    {

    }
    public void PlayAMortVoiceline()
    {

    }
    public void PlaySaleVetementVoiceline()
    {

    }
    public void PlayDeffripeLeVoiceline()
    {

    }
    public void PlayTransformeChiffonVoiceline()
    {

    }
    public void PlayVaTeFerVoiceline()
    {

    }
    public void PlayLeCombatPlieVoiceline()
    {

    }
    public void PlayTesVraimentMancheVoiceline()
    {

    }
    public void PlayBouffeLuiLesCouturesVoiceline()
    {

    }
    public void PlayVaTeFerRavalerVoiceline()
    {

    }
    public void PlayDecoudsLuiPochesVoiceline()
    {

    }
    #endregion

    #region SFX
    public void PlayMoteurSFX()
    {

    }
    public void PlayVapeurSFX()
    {

    }
    public void PlayCollisionWallSFX()
    {

    }
    public void PlayBrulureSFX()
    {

    }
    public void PlayButtonClicSFX()
    {

    }
    public void PlayCountdownSFX()
    {

    }
    #endregion

    #region Musics
    public void PlayMenuMusic()
    {

    }
    public void PlayArenaMusic()
    {

    }
    public void PlayEndScreenMusic()
    {

    }
    #endregion
}
