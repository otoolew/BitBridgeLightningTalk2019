// ----------------------------------------------------------------------------
// Author:      William O'Toole 
// Project:     BitBridge Lightning Talks 2019
// Date:        JUNE 2019
// ----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitBridge
{
    public class ActorIdleStateEUE : ActorStateEUE
    {
        public Material idleStateColorMaterial;
        public override void Enter()
        {
            Debug.Log(gameObject.name + " Entered IDLE State");
            activeState = true;
            actorController.CurrentState.stateName = stateName;
            actorController.ChangeColor(idleStateColorMaterial);
            PerformIdle();
        }

        public override void Exit()
        {
            activeState = false;
            Debug.Log(gameObject.name + " Exited IDLE State");
        }

        public override void StateUpdate()
        {
            //Debug.Log(gameObject.name + " Updated IDLE State");

            if (EnemyInRange())// if enemy is in range
            {
                actorController.ChangeState<ActorAttackStateEUE>();
            }

        }
        private void PerformIdle()
        {
            actorController.ActorsCurrentThought = "I am idle... so bored!";
        }

        private bool EnemyInRange()
        {
            // logic for checking if an enemy is in range.
            if (actorController.enemyInRange)
                return true;
            else
                return false;

            // Sugarless Syntactic version of code above
            //if (enemyInSight)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}