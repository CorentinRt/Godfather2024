using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class PublicEffects : MonoBehaviour
{

    [SerializeField] private List<GameObject> _publicObjects;

    [SerializeField] private float _jumpMinDuration;
    [SerializeField] private float _jumpMaxDuration;
    [SerializeField] private float _jumpMinPower;
    [SerializeField] private float _jumpMaxPower;

    [Button] private void PublicAllJump()
    {
        foreach (var pub in _publicObjects)
        {
            PublicJump(pub);
        }
    }

    private void PublicJump(GameObject pub)
    {
        float jumpPower = Random.Range(_jumpMinPower, _jumpMaxPower);
        float jumpDuration = Random.Range(_jumpMinDuration, _jumpMaxDuration);

        pub.transform.DOJump(pub.transform.position, jumpPower, 1, jumpDuration);
    }
}
