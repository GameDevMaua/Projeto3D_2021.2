using UnityEngine;

namespace State_Machine{
    public class StateManager : MonoBehaviour{
        public BaseState _currentState { get; set; }
        
        public Falling fallingState;
        public Flying flyingState;
        public Driving drivingState;
        
        
        private void Start() {
            fallingState = new Falling(this);
            flyingState = new Flying(this);
            drivingState = new Driving(this);
            
            _currentState = fallingState;
            
        }

        public void ChangeCurrentState(BaseState newState) {
            if(_currentState == newState) return;
            
            _currentState.OnStateLeaving();
            
            _currentState = newState;

            _currentState.OnStateEnter();
            
        }
        
        private void Update() {
            _currentState.OnExecuteState();
        }
    }
}