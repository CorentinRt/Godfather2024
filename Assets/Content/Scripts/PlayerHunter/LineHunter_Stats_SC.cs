using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LineHunter_Stats", menuName = "ScriptableObjects/LineHunter_Stats", order = 1)]
public class LineHunter_Stats_SC : ScriptableObject
{
    #region Fields
    [SerializeField] private float _lineWidth;
    [SerializeField] private float _lineDuration;

    #endregion

    #region Properties
    public float LineWidth { get => _lineWidth; set => _lineWidth = value; }
    public float LineDuration { get => _lineDuration; set => _lineDuration = value; }


    #endregion
}
