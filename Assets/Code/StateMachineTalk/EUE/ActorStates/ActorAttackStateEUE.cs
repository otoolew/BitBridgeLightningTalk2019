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
    public class ActorAttackStateEUE : ActorStateEUE
    {
        public Material attackStateColorMaterial;
        public override void Enter()
        {
            Debug.Log(gameObject.name + " Entered ATTACK State");
            activeState = true;
            actorController.CurrentState.stateName = stateName;
            actorController.ChangeColor(attackStateColorMaterial);
        }

        public override void Exit()
        {
            Debug.Log(gameObject.name + " Exited ATTACK State");
            activeState = false;
        }

        public override void StateUpdate()
        {
            // Implement Update Logic here.
            //Debug.Log(gameObject.name + " Updated ATTACK State");

            if (EnemyInRange()) // if enemy is in range
            {
                PerformAttack();
            }
            else
            {
                actorController.ActorsCurrentThought = "Enemy out of range...";
                actorController.ChangeState<ActorIdleStateEUE>();
            }
        }

        private void PerformAttack()
        {
            actorController.ActorsCurrentThought = "ATTACK!";
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