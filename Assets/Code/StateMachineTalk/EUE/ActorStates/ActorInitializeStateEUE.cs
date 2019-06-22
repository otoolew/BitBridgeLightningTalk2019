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
    public class ActorInitializeStateEUE : ActorStateEUE
    {
        public Material initializeStateColorMaterial;

        public override void Enter()
        {
            Debug.Log(gameObject.name + " Entered INITIALIZE State");
            activeState = true;
            actorController.CurrentState.stateName = stateName;
            actorController.ChangeColor(initializeStateColorMaterial);
            NeedToBeInUpdateInitializeMethod();
            //StartCoroutine(InitializeSequence()); // Use a coroutine to execute "Start -> Execute Logic -> then ChangeState
        }

        public override void Exit()
        {
            activeState = false;
            Debug.Log(gameObject.name + " Exited INITIALIZE State");
        }

        public override void StateUpdate()
        {
            Debug.Log(gameObject.name + " Updated INITIALIZE State");
            NeedToBeInUpdateInitializeMethod();
        }

        /// <summary>
        /// Example of a method that will not execute as planned
        /// </summary>
        private void NeedToBeInUpdateInitializeMethod()
        {
            actorController.HP = 50f;
            actorController.ActorsCurrentThought = "I feel stuck in a loop :(";
            actorController.ChangeState<ActorIdleStateEUE>(); // will never execute the Change of State...
        }

        IEnumerator InitializeSequence()
        {
            actorController.HP = 100f;
            actorController.ActorsCurrentThought = "I am Initialized!!!!";
            yield return null; // Returning null will return after the frame is finished
            actorController.ChangeState<ActorIdleStateEUE>();
        }

    }
}