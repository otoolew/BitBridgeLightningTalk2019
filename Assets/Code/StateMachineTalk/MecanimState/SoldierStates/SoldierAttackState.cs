using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackState : StateMachineBehaviour
{
    SoldierController soldierController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        soldierController = animator.GetComponent<SoldierController>();
        Debug.Log(soldierController.gameObject.name + " Entered ATTACK State");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Great place for an attack cooldown timer
        PerformAttack();
        animator.SetBool("EnemyInRange", soldierController.enemyInRange);
        animator.SetFloat("MoveVelocity", soldierController.NavAgent.velocity.magnitude);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(soldierController.gameObject.name + " Exited ATTACK State");
    }

    private void PerformAttack()
    {
        Debug.Log(soldierController.gameObject.name + " has Attacked!");
    }
}
