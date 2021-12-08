using System;
using Input_Swipe;
using Player;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace State_Machine{
    [Serializable]
    public class BaseState{
        protected StateManager _stateManager;
        private Animator _animator;
        public string _animateName;
        
        public BaseState(StateManager stateManager) {
            _stateManager = stateManager;
        }

        public virtual void OnStateEnter() {
            SwipeEventManager.UpSwipeEvent += OnSwipeUp;
            SwipeEventManager.DownSwipeEvent += OnSwipeDown;
            SwipeEventManager.LeftSwipeEvent += OnSwipeLeft;
            SwipeEventManager.RightSwipeEvent += OnSwipeRight;


            // _animator.Play(_animateName);

        }

        public virtual void OnExecuteState() {
            //todo: colocar pro gameobj do player seguir o target
        }
        
        public virtual void OnStreetCollided(GameObject obj){}
        
        
        public virtual void OnStateLeaving() {
            SwipeEventManager.UpSwipeEvent -= OnSwipeUp;
            SwipeEventManager.DownSwipeEvent -= OnSwipeDown;
            SwipeEventManager.LeftSwipeEvent -= OnSwipeLeft;
            SwipeEventManager.RightSwipeEvent -= OnSwipeRight;
        }

        public virtual void OnSwipeUp() {

            Debug.Log("Arrasta pra cima e ganhe promoção");

        }

        public virtual void OnSwipeDown() {
            
        }

        public virtual void OnSwipeLeft() {
            Debug.Log("Da um print ai pra ver se chama a função");
            PlayerTarget.Instance.MoveTargetHorizontaly(-1);
        }

        public virtual void OnSwipeRight() {
            PlayerTarget.Instance.MoveTargetHorizontaly(1);
        }
    }
}