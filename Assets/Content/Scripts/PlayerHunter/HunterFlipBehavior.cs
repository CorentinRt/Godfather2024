using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterFlipBehavior : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRd;


    private void Update()
    {
        UpdateFlip();
    }
    private void UpdateFlip()
    {
        Vector3 tempRot = transform.rotation.eulerAngles;

        if (tempRot.z % 360f <= 360f && tempRot.z % 360f >= 180f)
        {
            _spriteRd.flipY = false;
        }
        else
        {
            _spriteRd.flipY = true;
        }
    }
}
