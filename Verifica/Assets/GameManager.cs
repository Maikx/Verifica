using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager singleton;

    UiManager UiManager;
    //Altri Manager
    Animator GameSM;
    // Start is called before the first frame update

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        Setup();
    }
    
    /// <summary>
    /// Delegato che gestisce gli eventi lanciati dall'esterno per triggerare il cambio di stato della GameStateMachine
    /// </summary>
    public delegate void GameSMTriggerDelegate();

    //public static GameSMTriggerDelegate Setup;

    public static GameSMTriggerDelegate Idle;
    public static GameSMTriggerDelegate Walk;
    public static GameSMTriggerDelegate Run;
    public static GameSMTriggerDelegate Crouch;


    public static void Setup()
    {
        singleton.UiManager = FindObjectOfType<UiManager>();
        singleton.GameSM = singleton.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        EventSetup();
    }
    public static void EventSetup()
    {
        
    }

    void HandleGoToIdle()
    {
        if (!singleton.GameSM.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            
        }
    }

    private void OnDisable()
    {
        Idle -= singleton.HandleGoToIdle;
    }

}
