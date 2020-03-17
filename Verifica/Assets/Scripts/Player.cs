using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
public float rotationVelocity;
    public float walk, run;
public bool isRunning = false;


    CharacterController cController;
    // Update is called once per frame
    private void Start()
    {
       
    }


    void Rotate(float direction)
    {
        transform.Rotate(Vector3.up * rotationVelocity * Time.deltaTime * direction);
    }
    void Walk(int speed)
    {
        cController.Move(transform.forward * speed * walk * Time.deltaTime);
    }
    void Run(int speed)
    {
        cController.Move(transform.forward * speed * run * Time.deltaTime);
    }
    private void Awake()
    {
        cController = GetComponent<CharacterController>();
    }
    void Update()
    {
    if (Input.GetKey(KeyCode.A)) Rotate(-1);
    if (Input.GetKey(KeyCode.D)) Rotate(1);
    if (Input.GetKey(KeyCode.W)) Walk(1);
    if (Input.GetKey(KeyCode.S)) Walk(-1);
    if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {

            isRunning = true;
            Run(1);
            print("Running");

        }
        else
        {

            isRunning = false;
            print("Not Running");

        }
    }

}
