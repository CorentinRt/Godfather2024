using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoManager : MonoBehaviour
{
    private static TutoManager _instance;

    [SerializeField] private SlideToEffect _slideToEffect;
    
    [SerializeField] private float _tutoDuration;

    public static TutoManager Instance { get => _instance; set => _instance = value; }

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Two TutoManager singleton conflicted ! One has been destroyed !");
            Destroy(gameObject);
        }

        _instance = this;
    }
    private void Start()
    {
        LaunchTuto();
    }

    private void LaunchTuto()
    {
        _slideToEffect.SlideToEnd();

        StartCoroutine(TutoDurationCoroutine());
    }
    private void EndTuto()
    {
        _slideToEffect.SlideToStart();

        if (PhaseManager.Instance != null)
        {
            PhaseManager.Instance.RoundStart();
        }
    }
    private IEnumerator TutoDurationCoroutine()
    {
        yield return new WaitForSeconds(_tutoDuration);
        
        EndTuto();

        yield return null;
    }
}
