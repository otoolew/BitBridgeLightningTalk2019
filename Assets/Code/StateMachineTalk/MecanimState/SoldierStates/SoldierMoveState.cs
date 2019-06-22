using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMoveState : StateMachineBehaviour
{
    SoldierController soldierController;
    public float wonderRange;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        soldierController = animator.GetComponent<SoldierController>();
        Debug.Log(soldierController.gameObject.name + " Entered MOVE State");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (soldierController.NavAgent.remainingDistance <= 0.1f)
            soldierController.NavAgent.SetDestination(soldierController.GetRandomPointInArea());

        animator.SetFloat("MoveVelocity", soldierController.NavAgent.velocity.magnitude);
        animator.SetBool("EnemyInRange", soldierController.enemyInRange);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(soldierController.gameObject.name + " Exited MOVE State");
    }

}
