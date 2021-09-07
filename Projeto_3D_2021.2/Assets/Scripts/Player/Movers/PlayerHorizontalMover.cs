using System;
using System.Collections;
using Input_Swipe;

namespace Player
{
    public abstract class PlayerHorizontalMover : IState
    {
        private PlayerHorizontalMover _rightMover;
        private PlayerHorizontalMover _leftMover;
        public bool active;
        public bool animating;
        private void StartAnimating() => animating = true;
        private void StopAnimating() => animating = false;
        public void InjectInfo(PlayerHorizontalMover rightMover, PlayerHorizontalMover leftMover)
        {
            //todo:find something to do here
            _rightMover = rightMover;
            _leftMover = leftMover;
        }
        public void OnLeavingState()
        {
            active = false;
            SwipeEventManager.RightSwipeEvent -= OnSwipingRight;
            SwipeEventManager.LeftSwipeEvent -= OnSwipingLeft;
        }
        public void OnEnteringState()
        {
            active = true;
            SwipeEventManager.UpSwipeEvent += OnSwipingRight;
            SwipeEventManager.DownSwipeEvent += OnSwipingLeft;
        }
        private void OnSwipingRight() => PlayerManager.Instance.StartCoroutine(MovePlayerRight());
        private void OnSwipingLeft() =>  PlayerManager.Instance.StartCoroutine(MovePlayerLeft());
        protected abstract IEnumerator MovePlayerRight();
        protected abstract IEnumerator MovePlayerLeft();
    }
}