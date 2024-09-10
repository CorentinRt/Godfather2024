using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollision : MonoBehaviour
{
    private LineRenderer _line;

    public event Action<Collider2D> OnCollisionEnter;

    [SerializeField] private LayerMask _layerMask;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        CalculateColliderPoints();
    }

    private void CalculateColliderPoints()
    {
        if (_line.positionCount < 8)
            return;


        for (int i = 0; i < _line.positionCount; i++)
        {
            if ((i + 1) % 8 == 0)
            {
                Collider2D hit = Physics2D.OverlapCircle(_line.GetPosition(i), _line.startWidth / 2f, _layerMask);

                if (hit != null)
                {
                    OnCollisionEnter?.Invoke(hit);
                }
            }
        }

    }
    private void OnDrawGizmos()
    {
        if (_line != null)
        {
            Gizmos.color = Color.red;

            for (int i = 0; i < _line.positionCount; i++)
            {
                if ((i + 1) % 8 == 0)
                {
                    Vector3 point = _line.GetPosition(i);

                    Gizmos.DrawWireSphere(point, _line.startWidth / 2f);
                }
            }
        }
    }
}

