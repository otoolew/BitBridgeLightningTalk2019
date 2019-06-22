using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIdleState : StateMachineBehaviour
{
    SoldierController soldierController;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        soldierController = animator.GetComponent<SoldierController>();
        Debug.Log(soldierController.gameObject.name + " Entered IDLE State");
        soldierController.NavAgent.destination = soldierController.GetRandomPointInArea();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("EnemyInRange", soldierController.enemyInRange);
        animator.SetFloat("MoveVelocity", soldierController.NavAgent.velocity.magnitude);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(soldierController.gameObject.name + " Exited IDLE State");
    }
}
