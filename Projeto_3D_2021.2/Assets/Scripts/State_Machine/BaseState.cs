
using System;
using Input_Swipe;
using UnityEngine;

namespace State_Machine{
    [Serializable]
    public class BaseState{
        protected StateManager _stateManager;
        private Animator _animator;
        [SerializeField] private string _animateName;
        
        public BaseState(StateManager stateManager) {
            _stateManager = stateManager;
        }
        
        
        public virtual void OnStateEnter() {
            SwipeEventManager.UpSwipeEvent += OnSwipeUp;
            SwipeEventManager.DownSwipeEvent += OnSwipeDown;
            SwipeEventManager.LeftSwipeEvent += OnSwipeLeft;
            SwipeEventManager.RightSwipeEvent += OnSwipeRight;
            
            _animator.Play(_animateName);
            
        }

        public virtual void OnExecuteState() {
            //todo: colocar pro gameobj do player seguir o target
        }
        
        public virtual void OnStateLeaving() {
            SwipeEventManager.UpSwipeEvent -= OnSwipeUp;
            SwipeEventManager.DownSwipeEvent -= OnSwipeDown;
            SwipeEventManager.LeftSwipeEvent -= OnSwipeLeft;
            SwipeEventManager.RightSwipeEvent -= OnSwipeRight;
        }

        public virtual void OnSwipeUp() {
            
        }

        public virtual void OnSwipeDown() {
            
        }

        public virtual void OnSwipeLeft() {
            
        }

        public virtual void OnSwipeRight() {
            
        }
        
        
        
        

    }
}