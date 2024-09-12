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

    public void PlayRandomInsultes()
    {

    }

    #region Insultes
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
    public void PlayMoteurSFX()
    {
        _audioSource.PlayOneShot(_soundList.MoteurSFX);
    }
    public void PlayVapeurSFX()
    {
        int rand = Random.Range(0, _soundList.VapeurSFX.Count - 1);

        _audioSource.PlayOneShot(_soundList.VapeurSFX[rand]);
    }
    public void PlayCollisionWallSFX()
    {
        _audioSource.PlayOneShot(_soundList.CollisionWallSFX);
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
    public void PlayMenuMusic()
    {
        _audioSource.PlayOneShot(_soundList.MenuMusic);
    }
    public void PlayArenaMusic()
    {
        _audioSource.PlayOneShot(_soundList.ArenaMusic);
    }
    public void PlayCreditMusic()
    {
        _audioSource.PlayOneShot(_soundList.CreditMusic);
    }
    #endregion
}
