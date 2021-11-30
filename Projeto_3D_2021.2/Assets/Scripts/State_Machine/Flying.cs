using System;
using UnityEngine;

namespace State_Machine{
    [Serializable]
    public class Flying : BaseState{

        public Flying(StateManager stateManager) : base(stateManager) {
        }

        public override void OnExecuteState() {
            Debug.Log("Estou voando, jack!");
        }

        public override void OnStateEnter() {
            base.OnStateEnter();
        }

        public override void OnStateLeaving() {
            base.OnStateLeaving();
        }

        public override void OnSwipeDown() {
            _stateManager.ChangeCurrentState(_stateManager.fallingState);
        }


    }
}