using System;
using System.Collections;
using Input_Swipe;

namespace Player
{
    public class PlayerHorizontalMover : IState
    {
        private PlayerMoverManager _playerMoverManager;
        private PlayerHorizontalMover _rightMover;
        private PlayerHorizontalMover _leftMover;
        public bool active;
        
        
        public void InjectInfo(PlayerMoverManager playerMoverManager ,PlayerHorizontalMover rightMover,PlayerHorizontalMover leftMover)
        {
            _playerMoverManager = playerMoverManager;
            _rightMover = rightMover;
            _leftMover = leftMover;
        }
        

        public void OnLeavingState()
        {
            active = false;
            SwipeManager.RightSwipeEvent -= SwipeRight;
            SwipeManager.LeftSwipeEvent -= SwipeLeft;
        }

        public void OnEnteringState()
        {
            active = true;
            SwipeManager.UpSwipeEvent += SwipeRight;
            SwipeManager.DownSwipeEvent += SwipeLeft;
        }
        
        private void SwipeRight() => _playerMoverManager.StartCoroutine(MovePlayerRight());
        private void SwipeLeft() => _playerMoverManager.StartCoroutine(MovePlayerLeft());

        protected virtual IEnumerator MovePlayerRight()
        {
            throw new NotImplementedException();
        }

        protected virtual IEnumerator MovePlayerLeft()
        {
            throw new NotImplementedException();
        }
    }
}