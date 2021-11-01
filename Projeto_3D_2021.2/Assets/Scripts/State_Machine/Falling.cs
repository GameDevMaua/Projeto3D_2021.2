
using System;
using UnityEngine;

namespace State_Machine{
    [Serializable]
    public class Falling: BaseState{
        
        
        
        public Falling(StateManager stateManager) : base(stateManager){
        }
        public override void OnExecuteState() {
        }

        public override void OnStateEnter() {
            base.OnStateEnter();
            
        }

        public override void OnStateLeaving() {
            base.OnStateLeaving();
        }


        public override void OnSwipeUp() {
            _stateManager.ChangeCurrentState(_stateManager.flyingState);
        }

        public override void OnSwipeDown() {
            _stateManager.ChangeCurrentState(_stateManager.drivingState);
        }
    }
}