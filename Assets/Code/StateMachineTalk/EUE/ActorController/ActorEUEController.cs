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
    public class ActorEUEController : StateMachineEUE
    {
        // This is a verbose formatting style useing fields and properties 
        [SerializeField] private float hP;
        public float HP { get => hP; set => hP = value; }

        // This is the short hand Unity Public Field style
        public string ActorsCurrentThought;
        public bool enemyInRange;

        // Start is called before the first frame update
        void Start()
        {
            // You need a State to enter on Start
            ChangeState<ActorInitializeStateEUE>();
        }

        // Update is called once per frame
        void Update()
        {
            _currentState.StateUpdate();
        }
        public void ChangeColor(Material material)
        {
            transform.Find("Model").Find("Cube").GetComponent<MeshRenderer>().material = material;
        }
    }
}