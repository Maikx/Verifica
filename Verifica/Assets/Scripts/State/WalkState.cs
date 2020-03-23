using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : StateMachineBehaviour
{
    Transform transform;
    public float rotationVelocity;
    public float walk;
    CharacterController cController;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.transform;
        Player player = transform.GetComponent<Player>();
        rotationVelocity = player.rotationVelocity;
        walk = player.walk;
        cController = player.cController;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKey(KeyCode.A)) Rotate(-1);
        if (Input.GetKey(KeyCode.D)) Rotate(1);
        if (Input.GetKey(KeyCode.W)) Walk(1);
        if (Input.GetKey(KeyCode.S)) Walk(-1);
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Faccio qualcosa : Es : Disattivo Ui Main Menu e attivo UI Gameplay
    }

    //// OnStateMove is called right after Animator.OnAnimatorMove()
    // override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     // Implement code that processes and affects root motion
    // }

    // //OnStateIK is called right after Animator.OnAnimatorIK()
    // override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     // Implement code that sets up animation IK (inverse kinematics)
    void Rotate(float direction)
    {
        transform.Rotate(Vector3.up * rotationVelocity * Time.deltaTime * direction);
    }
    void Walk(int speed)
    {
        cController.Move(transform.forward * speed * walk * Time.deltaTime);
    }
}

