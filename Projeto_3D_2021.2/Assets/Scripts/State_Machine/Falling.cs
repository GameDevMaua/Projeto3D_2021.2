using System;
using Player;
using UnityEngine;
using UnityEngine.AI;
using Vehicle_Manager;

namespace State_Machine{
    [Serializable]
    public class Falling: BaseState{
        
        public Falling(StateManager stateManager) : base(stateManager){
        }
        public override void OnExecuteState() {

            Debug.Log("Caindo");
        }

        public override void OnStateEnter() {
            base.OnStateEnter();
            PlayerCollisions.SubscribeOnAEvent("Street", OnStreetCollided);
            PlayerCollisions.SubscribeOnAEvent("Car", OnCarCollide);
        }

        public override void OnStateLeaving() {
            base.OnStateLeaving();
            PlayerCollisions.UnsubscribeOnAEvent("Car", OnCarCollide);
            PlayerCollisions.UnsubscribeOnAEvent("Street", OnStreetCollided);
        }

        public override void OnSwipeUp() {
            if(PlayerSingleton.Instance.JetpackFuel > 0)
                _stateManager.ChangeCurrentState(_stateManager.flyingState);
        }

        public override void OnStreetCollided(GameObject obj) {
            Debug.Log("Evento chamado street");
            _stateManager.ChangeCurrentState(_stateManager.deadState);
        }

        public void OnCarCollide(GameObject car) {
            Debug.Log("Evento chamado car");
            _stateManager.drivingState.Car = car;
            _stateManager.drivingState.CarCollision = car.AddComponent<CarCollisions>();
            _stateManager.ChangeCurrentState(_stateManager.drivingState);
        }
    }
}