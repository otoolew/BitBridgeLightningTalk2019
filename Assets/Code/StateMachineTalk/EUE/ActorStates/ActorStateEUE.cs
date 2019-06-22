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
    public abstract class ActorStateEUE : StateEUE
    {
        // Add whatever components you would like to access here.
        protected ActorEUEController actorController;

        protected override void Awake()
        {
            base.Awake();
            actorController = GetComponent<ActorEUEController>();
        }
    }
}