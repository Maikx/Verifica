using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
public float rotationVelocity;
public float walk, run;
public bool isCrouching = false;
public bool isRunning = false;
public CharacterController cController;
    // Update is called once per frame
    private void Start()
    {
       
    }
    private void Awake()
    {
        cController = GetComponent<CharacterController>();
    }
}
