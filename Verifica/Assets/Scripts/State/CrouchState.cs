﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : StateMachineBehaviour
{
    Transform transform;
    public bool isCrouching;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player player = transform.GetComponent<Player>();
        isCrouching = player.isCrouching;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(animator);
        }
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
    void Crouch(Animator aAnimator)
    {
        aAnimator.SetTrigger("Crouch");
    }
}
