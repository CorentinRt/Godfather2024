using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class PublicEffects : MonoBehaviour
{

    [SerializeField] private List<GameObject> _publicObjects;

    [SerializeField] private float _jumpDuration;
    [SerializeField] private float _jumpPower;

    [Button] private void PublicAllJump()
    {
        foreach (var pub in _publicObjects)
        {
            PublicJump(pub);
        }
    }

    private void PublicJump(GameObject pub)
    {
        pub.transform.DOJump(pub.transform.position, _jumpPower, 1, _jumpDuration);
    }
}
