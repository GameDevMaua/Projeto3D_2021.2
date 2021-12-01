using UnityEngine;

namespace State_Machine{
    public class StateManager : MonoBehaviour{
        public BaseState _currentState;
        
        public Falling fallingState;
        public Flying flyingState;
        public Driving drivingState;
        
        
        private void Start() {
            fallingState = new Falling(this);
            flyingState = new Flying(this);
            drivingState = new Driving(this);

            
            _currentState = fallingState;


            fallingState._animateName = "Falling";
            flyingState._animateName  = "Flying";
            drivingState._animateName = "Driving";
            ChangeCurrentState(fallingState);



        }

        public void ChangeCurrentState(BaseState newState) {
            
            _currentState.OnStateLeaving();
            
            _currentState = newState;

            _currentState.OnStateEnter();
            
        }
        
        private void Update() {
            _currentState.OnExecuteState();
        }
    }
}