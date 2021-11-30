using System;
using Player;
using UnityEngine;
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

            PlayerCollisions.OnCarCollisionEvent += OnCarCollide;
        }

        public override void OnStateLeaving() {
            base.OnStateLeaving();
            PlayerCollisions.OnCarCollisionEvent -= OnCarCollide;
        }


        public bool HaveEnoughFuel() {
            return true;
        }
        
        public override void OnSwipeUp() {
            if(HaveEnoughFuel())
                _stateManager.ChangeCurrentState(_stateManager.flyingState);
            else {
                //todo: fazer um efeito pra mostrar que não tem combustível  
                
            }
            
        }

        public override void OnSwipeDown() {
            _stateManager.ChangeCurrentState(_stateManager.drivingState);
        }

        public void OnCarCollide(GameObject car) {
            _stateManager.drivingState.Car = car;
            _stateManager.drivingState.CarCollision = car.AddComponent<CarCollisions>();
            _stateManager.ChangeCurrentState(_stateManager.drivingState);
        }
    }
}