using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class SlideToEffect : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;

    [SerializeField] private float _slideToEndDuration;
    [SerializeField] private float _slideToStartDuration;

    private Tweener _slideToStartTweener;
    private Tweener _slideToEndTweener;

    [Button] public void SlideToEnd()
    {
        _slideToEndTweener = transform.DOMove(_end.position, _slideToEndDuration);
    }

    [Button] public void SlideToStart()
    {
        _slideToStartTweener = transform.DOMove(_start.position, _slideToStartDuration);
    }
}
