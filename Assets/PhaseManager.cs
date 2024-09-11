using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{

    [SerializeField]
    private float _cooldownDuration; 
    private float _VictoryScreenDuration;
    
    void Start()
    {
        RoundStart();
    }

    void RoundStart()
    {
        // disable inputs
        // teleports Players
        // countdown animation
        Invoke("endOfCooldown", _cooldownDuration);
    }

    void endOfCooldown()
    {
        // enable inputs
        // start timer
    }


    void Update()
    {
        //  if (pyjama dies || timer ends)
        //  {
        //      if (pyjama dies)
        //      {
        //          VictoryAnimation(FerARepasser);
        //      } else
        //      {
        //          VictoryAnimation(pyjama);
        //      }
        //      Invoke("RoundStart", _VictoryScreenDuration);
        //  }
    }
}
