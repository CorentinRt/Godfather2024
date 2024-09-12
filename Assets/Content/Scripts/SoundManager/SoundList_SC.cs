using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundList", menuName = "ScriptableObjects/SoundList", order = 1)]
public class SoundList_SC : ScriptableObject
{
    #region Fields
    [Header("Voicelines")]
    [SerializeField] private AudioClip _souffranceVoiceline;
    [SerializeField] private AudioClip _deceptionVoiceline;
    [SerializeField] private List<AudioClip> _vetementsTombentVoiceline;

    [Space(10)]

    [Header("Insultes")]

    [SerializeField] private List<AudioClip> _insultes;
    [SerializeField] private float _timeBetweenInsultes;

    [Space(10)]

    [SerializeField] private AudioClip _brulezLeVoiceline;
    [SerializeField] private AudioClip _repasseLeVoiceline;
    [SerializeField] private AudioClip _oUAISVoiceline;
    [SerializeField] private AudioClip _arracheCouturesVoiceline;
    [SerializeField] private List<AudioClip> _laveJavelVoiceline;
    [SerializeField] private List<AudioClip> _chiffoneLeVoiceline;
    [SerializeField] private AudioClip _auFeuVoiceline;
    [SerializeField] private AudioClip _aMortVoiceline;
    [SerializeField] private List<AudioClip> _saleVetementVoiceline;
    [SerializeField] private List<AudioClip> _deffripeLeVoiceline;
    [SerializeField] private AudioClip _transformeChiffonVoiceline;
    [SerializeField] private List<AudioClip> _vaTeFerVoiceline;
    [SerializeField] private AudioClip _leCombatPlieVoiceline;
    [SerializeField] private AudioClip _tesVraimentMancheVoiceline;
    [SerializeField] private List<AudioClip> _bouffeLuiLesCouturesVoiceline;
    [SerializeField] private AudioClip _vaTeFerRavalerVoiceline;
    [SerializeField] private List<AudioClip> _decoudsLuiPochesVoiceline;

    [Space(10)]

    [Header("SFX")]

    [SerializeField] private AudioClip _moteurSFX;
    [SerializeField] private List<AudioClip> _vapeurSFX;
    [SerializeField] private float _timeBetweenVapeur;
    [SerializeField] private List<AudioClip> _collisionWallSFX;
    [SerializeField] private AudioClip _brulureSFX;
    [SerializeField] private AudioClip _buttonClicSFX;
    [SerializeField] private AudioClip _countdownSFX;

    [Space(10)]

    [Header("Music")]

    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _arenaMusic;
    [SerializeField] private AudioClip _creditMusic;


    #endregion


    #region Properties
    public AudioClip SouffranceVoiceline { get => _souffranceVoiceline; set => _souffranceVoiceline = value; }
    public AudioClip DeceptionVoiceline { get => _deceptionVoiceline; set => _deceptionVoiceline = value; }
    public List<AudioClip> VetementsTombentVoiceline { get => _vetementsTombentVoiceline; set => _vetementsTombentVoiceline = value; }



    public List<AudioClip> Insultes { get => _insultes; set => _insultes = value; }
    public float TimeBetweenInsultes { get => _timeBetweenInsultes; set => _timeBetweenInsultes = value; }


    public AudioClip BrulezLeVoiceline { get => _brulezLeVoiceline; set => _brulezLeVoiceline = value; }
    public AudioClip RepasseLeVoiceline { get => _repasseLeVoiceline; set => _repasseLeVoiceline = value; }
    public AudioClip OUAISVoiceline { get => _oUAISVoiceline; set => _oUAISVoiceline = value; }
    public AudioClip ArracheCouturesVoiceline { get => _arracheCouturesVoiceline; set => _arracheCouturesVoiceline = value; }
    public List<AudioClip> LaveJavelVoiceline { get => _laveJavelVoiceline; set => _laveJavelVoiceline = value; }
    public List<AudioClip> ChiffoneLeVoiceline { get => _chiffoneLeVoiceline; set => _chiffoneLeVoiceline = value; }
    public AudioClip AuFeuVoiceline { get => _auFeuVoiceline; set => _auFeuVoiceline = value; }
    public AudioClip AMortVoiceline { get => _aMortVoiceline; set => _aMortVoiceline = value; }
    public List<AudioClip> SaleVetementVoiceline { get => _saleVetementVoiceline; set => _saleVetementVoiceline = value; }
    public List<AudioClip> DeffripeLeVoiceline { get => _deffripeLeVoiceline; set => _deffripeLeVoiceline = value; }
    public AudioClip TransformeChiffonVoiceline { get => _transformeChiffonVoiceline; set => _transformeChiffonVoiceline = value; }
    public List<AudioClip> VaTeFerVoiceline { get => _vaTeFerVoiceline; set => _vaTeFerVoiceline = value; }
    public AudioClip LeCombatPlieVoiceline { get => _leCombatPlieVoiceline; set => _leCombatPlieVoiceline = value; }
    public AudioClip TesVraimentMancheVoiceline { get => _tesVraimentMancheVoiceline; set => _tesVraimentMancheVoiceline = value; }
    public List<AudioClip> BouffeLuiLesCouturesVoiceline { get => _bouffeLuiLesCouturesVoiceline; set => _bouffeLuiLesCouturesVoiceline = value; }
    public AudioClip VaTeFerRavalerVoiceline { get => _vaTeFerRavalerVoiceline; set => _vaTeFerRavalerVoiceline = value; }
    public List<AudioClip> DecoudsLuiPochesVoiceline { get => _decoudsLuiPochesVoiceline; set => _decoudsLuiPochesVoiceline = value; }


    public AudioClip MoteurSFX { get => _moteurSFX; set => _moteurSFX = value; }
    public List<AudioClip> VapeurSFX { get => _vapeurSFX; set => _vapeurSFX = value; }
    public float TimeBetweenVapeur { get => _timeBetweenVapeur; set => _timeBetweenVapeur = value; }
    public List<AudioClip> CollisionWallSFX { get => _collisionWallSFX; set => _collisionWallSFX = value; }
    public AudioClip BrulureSFX { get => _brulureSFX; set => _brulureSFX = value; }
    public AudioClip ButtonClicSFX { get => _buttonClicSFX; set => _buttonClicSFX = value; }
    public AudioClip CountdownSFX { get => _countdownSFX; set => _countdownSFX = value; }


    public AudioClip MenuMusic { get => _menuMusic; set => _menuMusic = value; }
    public AudioClip ArenaMusic { get => _arenaMusic; set => _arenaMusic = value; }
    public AudioClip CreditMusic { get => _creditMusic; set => _creditMusic = value; }


    #endregion
}
