
using Player;
using UnityEngine;
using Vehicle_Manager;

namespace State_Machine{
    public class Driving : BaseState{

        public GameObject Car { get; set; }
        
        public CarCollisions CarCollision { get; set; } 

        public Driving(StateManager stateManager) : base(stateManager) {
            
        }
        
        public override void OnExecuteState() {
            
        }

        public override void OnStateEnter() {
            base.OnStateEnter();
            
            CarCollision.OnCarCrashEvent += OnCarCrashed;
        }

        public override void OnStateLeaving() {
            base.OnStateLeaving();
            CarCollision.OnCarCrashEvent -= OnCarCrashed;
        }

        public override void OnSwipeUp() {
            //todo:Verificar se alterar para o estado caindo é a melhor opção
            _stateManager.ChangeCurrentState(_stateManager.fallingState);
        }

        public override void OnSwipeLeft() {
            
        }

        public override void OnSwipeRight() {
      
        }

        public void OnCarCrashed(GameObject otherCar) {
            //todo: aplicar força no singlenton do player
            _stateManager.ChangeCurrentState(_stateManager.fallingState);
        }
    }
}