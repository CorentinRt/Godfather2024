using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhaseManager : MonoBehaviour
{

    [SerializeField]
    private float _cooldownDuration;
    [SerializeField]
    private float _VictoryScreenDuration;

    [SerializeField] private PlayerInput _playerInput;

    public PlayerHunterBehavior IronBehavior;
    public HunterLineBehavior LineBehavior;

    public GameObject Hunter;
    public GameObject Prey;

    [SerializeField]
    private float _spawnPoint;


    private float _currentTime;
    private float _endOfCooldown;
    
    void Start()
    {
        RoundStart();
    }

    void RoundStart()
    {
        // disable inputs
        IronBehavior.enabled = false;
        LineBehavior.enabled = false;
        _playerInput.actions.FindAction("MouseRotationHunter").Disable();
        // teleport Players
        Hunter.transform.position = new Vector3(-_spawnPoint, 0, 0);
        Prey.transform.position = new Vector3(_spawnPoint, 0, 0);

        // countdown animation


        Invoke("endOfCooldown", _cooldownDuration);
    }

    void endOfCooldown()
    {
        // enable inputs
        _playerInput.actions.FindAction("MouseRotationHunter").Enable();
        IronBehavior.enabled = true;
        LineBehavior.enabled = true;
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
