using System;
using UnityEngine;

namespace State_Machine{
    [Serializable]
    public class DeadState : BaseState{
        // public DeadState(StateManager stateManager) : base(stateManager) {
        // }

        public override void OnExecuteState() {
            Debug.Log("Morri!");
        }
    }
}