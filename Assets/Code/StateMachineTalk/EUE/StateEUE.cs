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
    public abstract class StateEUE : MonoBehaviour
    {
        public string stateName;
        public bool activeState;

        #region EUE Pattern
        /// <summary>
        /// Executes first when the StateMachine Enters this specific State
        /// </summary>
        public abstract void Enter();
        /// <summary>
        /// Executes the States Update logic
        /// </summary>
        public abstract void StateUpdate();
        /// <summary>
        /// Executes when the state exits this state
        /// </summary>
        public abstract void Exit();
        #endregion

        #region Monobehaviour
        protected virtual void Awake()
        {

        }
        #endregion
    }
}