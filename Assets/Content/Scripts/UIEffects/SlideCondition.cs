using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCondition : MonoBehaviour
{
    
    private SlideToEffect EndScreen;

    private void Awake()
    {
        EndScreen = GetComponent<SlideToEffect>();
    }

    private void Start()
    {
        EndScreen.SlideToEnd();
    }
}
