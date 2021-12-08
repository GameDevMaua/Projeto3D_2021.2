
using System;
using Player;
using UnityEngine;
using Vehicle_Manager;

namespace State_Machine{
    [Serializable]
    public class Driving : BaseState{

        public GameObject Car { get; set; }
        
        public CarCollisions CarCollision { get; set; } 

        public Driving(StateManager stateManager) : base(stateManager) {
            
        }
        
        public override void OnExecuteState()
        {
            Debug.LogWarning("criar uma action para quando estiver segurando na tela e conectar a função q vai atualizar a variavel InputManager.Instance.touchPosition");
            var touchPositionInfo = InputManager.Instance.touchPosition;
            PlayerTarget.Instance.MovePlayerByDeltaX(touchPositionInfo.deltaTouchPosition.x,touchPositionInfo.deltaTimeTouchPosition);
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
            Debug.Log("SwipeUp na classe Driving");
            //todo:Verificar se alterar para o estado caindo é a melhor opção
            _stateManager.ChangeCurrentState(_stateManager.fallingState);
        }



        public void OnCarCrashed(GameObject otherCar) {
            //todo: aplicar força no singlenton do player
            _stateManager.ChangeCurrentState(_stateManager.fallingState);
        }
    }
}