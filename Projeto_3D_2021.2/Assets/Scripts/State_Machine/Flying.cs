using System;
using Player;
using UnityEngine;

namespace State_Machine{
    [Serializable]
    public class Flying : BaseState{

        // public Flying(StateManager stateManager) : base(stateManager) {
        // }

        private PlayerSingleton _player;
        private PlayerTarget _playerTarget;

        private Rigidbody _rgb;
        
        [SerializeField] private float _maximumHeight;
        [SerializeField] private float _flyingVel;
        
        public override void OnExecuteState() {

            if(!PlayerSingleton.Instance.CanFly) 
                _stateManager.ChangeCurrentState(_stateManager.fallingState);


            _rgb.velocity = new Vector3(_rgb.velocity.x, _playerTarget.transform.position.y >= _maximumHeight ? _flyingVel : 0f, _rgb.velocity.z); 
            _player.JetpackFuel -= Time.deltaTime;



            var playerTargetRgb = _playerTarget.GetComponent<Rigidbody>();

            // _playerTarget.transform.position.y >= _maximumHeight ? _flyingVel : 0f;


            // var playerTargetPosition = _playerTarget.transform.position;
            //
            // playerTargetPosition = new Vector3(playerTargetPosition.x,
            //     Mathf.Min(playerTargetPosition.y, _maximumHeight), playerTargetPosition.z);
            //
            // _playerTarget.transform.position = playerTargetPosition;
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