using UnityEngine;

namespace State_Machine{
    public class DeadState : BaseState{
        public DeadState(StateManager stateManager) : base(stateManager) {
        }

        public override void OnExecuteState() {
            Debug.Log("Morri!");
        }
    }
}