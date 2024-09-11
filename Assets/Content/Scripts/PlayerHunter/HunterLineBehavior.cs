using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class HunterLineBehavior : MonoBehaviour
{
    #region Fields
    [Header("Setup")]
    [SerializeField] private LineRenderer _lavaLine;
    [SerializeField] private LineCollision _lineCollision;

    private List<Vector3> _linePositions;
    private List<float> _linePointsLifetime;

    [Header("Tweek value")]
    [SerializeField] private float _lineDuration;
    [SerializeField] private bool _isActive;



    #endregion

    #region Properties
    public List<Vector3> LinePositions { get => _linePositions; set => _linePositions = value; }



    #endregion


    private void Awake()
    {
        _linePositions = new List<Vector3>();
        _linePointsLifetime = new List<float>();
    }
    private void Start()
    {
        if (_lineCollision != null)
        {
            _lineCollision.OnCollisionEnter += HandleCollision;
        }
        else
        {
            Debug.LogWarning("Line Collision Missing on HunterLineBehavior !!! Collision won't work !!!");
        }
    }
    private void OnDestroy()
    {
        if (_lineCollision != null)
        {
            _lineCollision.OnCollisionEnter -= HandleCollision;
        }
    }
    private void Update()
    {
        CheckRemovePointLavaLine();
        if (_isActive)
        {
            AddPointLavaLine(transform.position);
        }
    }

    #region Add/Remove Line
    private void AddPointLavaLine(Vector3 point)
    {
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
                _linePointsLifetime[i] -= Time.deltaTime;
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
        _linePositions.RemoveAt(index);


        if (_lavaLine.positionCount != 0)
            _lavaLine.positionCount--;
    }
    #endregion

    private void HandleCollision(Collider2D hit)
    {
        if (hit == null)
            return;

        if (hit.CompareTag("PlayerPrey"))
        {
            hit.GetComponent<PlayerPrey>().Die();
            //Debug.Log("Collision");
        }
    }
}
