using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HunterLineBehavior : MonoBehaviour
{
    #region Fields
    [SerializeField] private LineRenderer _lavaLine;

    [SerializeField] private float _lineDuration;

    private List<Vector3> _linePositions;
    private List<float> _linePointsLifetime;

    [SerializeField] private bool _isActive;

    #endregion


    private void Awake()
    {
        _linePositions = new List<Vector3>();
        _linePointsLifetime = new List<float>();
    }
    private void FixedUpdate()
    {
        CheckRemovePointLavaLine();
        if (_isActive)
        {
            AddPointLavaLine(transform.position);
        }

    }

    private void AddPointLavaLine(Vector3 point)
    {
        Debug.Log("Add");
        _lavaLine.positionCount++;

        _linePointsLifetime.Add(_lineDuration);

        _linePositions.Add(point);

        _lavaLine.SetPositions(_linePositions.ToArray());
    }
    private void CheckRemovePointLavaLine()
    {
        for (int i = _linePointsLifetime.Count - 1; i >= 0; i--)
        {
            if (_linePointsLifetime[i] > 0f)
            {
                _linePointsLifetime[i] -= Time.fixedDeltaTime;
            }
            else
            {
                RemovePointLavaLine(i);
                _linePointsLifetime.RemoveAt(i);
            }
        }

        _lavaLine.SetPositions(_linePositions.ToArray());
    }
    private void RemovePointLavaLine(int index)
    {
        Debug.Log("Remove");
        _linePositions.RemoveAt(index);


        if (_lavaLine.positionCount != 0)
            _lavaLine.positionCount--;
    }
}
