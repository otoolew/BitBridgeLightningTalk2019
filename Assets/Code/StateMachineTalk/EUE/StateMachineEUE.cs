// ----------------------------------------------------------------------------
// Author:      Jonathan Parham 
// Modified:    William O'Toole
// Project:     BitBridge Lightning Talks 2019
// Date:        JUNE 2019
// ----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitBridge
{
    /// <summary>
    /// StateMachineEUE is short for StateMachine Enter Update Exit. A more common state machine pattern
    /// </summary>
    public class StateMachineEUE : MonoBehaviour
    {
        public string stateName;
        public virtual StateEUE CurrentState
        {
            get { return _currentState; }
            set { Transition(value); }
        }
        protected StateEUE _currentState;
        protected bool _inTransition;

        public virtual T GetState<T>() where T : StateEUE
        {
            T target = GetComponent<T>();
            if (target == null)
                target = gameObject.AddComponent<T>();
            return target;
        }

        public virtual void ChangeState<T>() where T : StateEUE
        {
            CurrentState = GetState<T>();
            stateName = CurrentState.stateName;
        }

        protected virtual void Transition(StateEUE value)
        {
            if (_currentState == value || _inTransition)
                return;

            _inTransition = true;

            if (_currentState != null)
                _currentState.Exit();

            _currentState = value;

            if (_currentState != null)
                _currentState.Enter();

            _inTransition = false;
        }
        void OnGUI()
        {
            GUI.TextArea(new Rect(10, 10, 300, 25), gameObject.name + " " + stateName);
        }
    }
}