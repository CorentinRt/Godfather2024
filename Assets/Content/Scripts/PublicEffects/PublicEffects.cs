using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class PublicEffects : MonoBehaviour
{
    [SerializeField] private List<GameObject> _publicObjects;
    [SerializeField] private List<Animator> _publicAnimators;

    [SerializeField] private float _jumpMinDuration;
    [SerializeField] private float _jumpMaxDuration;
    [SerializeField] private float _jumpMinPower;
    [SerializeField] private float _jumpMaxPower;

    private bool _canJump;


    private ArenaManager _arenaManager;


    private void Start()
    {
        _arenaManager = ArenaManager.Instance;

        if (_arenaManager != null)
        {
            _arenaManager._onCollisionHunter += PublicAllJump;
        }
        else
        {
            Debug.LogWarning("No singleton arenaManager found !! Public won't jump !!!");
        }

        SetAllColorTypeVetements();

        _canJump = true;
    }
    private void OnDestroy()
    {
        if (_arenaManager != null)
        {
            _arenaManager._onCollisionHunter -= PublicAllJump;
        }
    }

    #region Jump
    [Button] private void PublicAllJump()
    {
        if (!_canJump)
            return;

        _canJump = false;

        foreach (var pub in _publicObjects)
        {
            PublicJump(pub);
        }

        StartCoroutine(JumpCooldown());
    }
    private void PublicJump(GameObject pub)
    {
        float jumpPower = Random.Range(_jumpMinPower, _jumpMaxPower);
        float jumpDuration = Random.Range(_jumpMinDuration, _jumpMaxDuration);

        pub.transform.DOJump(pub.transform.position, jumpPower, 1, jumpDuration);
    }
    private IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(_jumpMaxDuration + 0.5f);

        _canJump = true;

        yield return null;
    }
    #endregion

    #region SetVetements
    private void SetAllColorTypeVetements()
    {
        foreach (var pubA in _publicAnimators)
        {
            int type = Random.Range(0, 2);
            int color = Random.Range(0, 3);

            switch (type)
            {
                case 0:
                    pubA.SetBool("SetTypeChemise", true);
                    break;
                case 1:
                    pubA.SetBool("SetTypeCostard", true);
                    break;
            }
            switch (color)
            {
                case 0:
                    pubA.SetBool("SetColorBlanc", true);
                    break;
                case 1:
                    pubA.SetBool("SetColorGris", true);
                    break;
                case 2:
                    pubA.SetBool("SetColorNoire", true);
                    break;
            }
        }
    }
    #endregion
}
