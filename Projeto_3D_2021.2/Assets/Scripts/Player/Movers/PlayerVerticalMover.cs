using System;
using System.Collections;
using Input_Swipe;

namespace Player
{
    public abstract class PlayerVerticalMover: IState
    {
        private PlayerVerticalMover _upMover; // todo connect this to the state machine and make some function that accept this
        private PlayerVerticalMover _downMover;
        public bool active;
        public bool animating;
        public void InjectInfo( PlayerVerticalMover upMover,PlayerVerticalMover downMover)
        {
            _upMover = upMover;
            _downMover = downMover;
        }
        protected virtual void OnFixedUpdate(){}
        public virtual void OnLeavingState()
        {
            active = false;
            SwipeEventManager.UpSwipeEvent -= SwipeUp;
            SwipeEventManager.DownSwipeEvent -= SwipeDown;

            PlayerEventManager.FixedUpdateEvent -= OnFixedUpdate;
        }
        public virtual void OnEnteringState()
        {
            active = true;
            SwipeEventManager.UpSwipeEvent += SwipeUp;
            SwipeEventManager.DownSwipeEvent += SwipeDown;

            PlayerEventManager.FixedUpdateEvent += OnFixedUpdate;
        }
        private void SwipeUp() => PlayerManager.Instance.StartCoroutine(OnSwipeUp());
        private void SwipeDown() => PlayerManager.Instance.StartCoroutine(OnSwipeDown());
        protected abstract IEnumerator OnSwipeUp();
        protected abstract IEnumerator OnSwipeDown();
    }
}