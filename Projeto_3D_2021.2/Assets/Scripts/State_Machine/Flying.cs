using System;
using Player;
using UnityEngine;

namespace State_Machine{
    [Serializable]
    public class Flying : BaseState{

        public Flying(StateManager stateManager) : base(stateManager) {
        }

        private PlayerSingleton _player;
        private PlayerTarget _playerTarget;

        private Rigidbody _rgb;
        
        public override void OnExecuteState() {

            if(!PlayerSingleton.Instance.CanFly) 
                _stateManager.ChangeCurrentState(_stateManager.fallingState);
            
           
            _rgb.AddForce(Vector3.up * 4, ForceMode.Acceleration); //esse 4 é totalmente arbitrário
            _player.JetpackFuel -= Time.deltaTime;
            
        }
        
        
        public override void OnStateEnter() {
            base.OnStateEnter();
            _player = PlayerSingleton.Instance;
            _playerTarget = PlayerTarget.Instance;
            
            _rgb = _playerTarget.GetComponent<Rigidbody>();
            
            PlayerCollisions.SubscribeOnAEvent("Street", OnStreetCollided);
        }

        public override void OnStateLeaving() {
            base.OnStateLeaving();
            PlayerCollisions.UnsubscribeOnAEvent("Street", OnStreetCollided);
        }


        public override void OnSwipeDown() {
            _stateManager.ChangeCurrentState(_stateManager.fallingState);
        }
        
        public override void OnStreetCollided(GameObject obj) {
            _stateManager.ChangeCurrentState(_stateManager.deadState);
        }
        
    }
}