using System;
using System.Collections;
using Input_Swipe;

namespace Player
{
    public class PlayerVerticalMover: IState
    {
        private PlayerMoverManager _playerMoverManager;
        private PlayerVerticalMover _upMover;
        private PlayerVerticalMover _downMover;
        public bool active;
        
        
        public void InjectInfo(PlayerMoverManager playerMoverManager ,PlayerVerticalMover upMover,PlayerVerticalMover downMover)
        {
            _playerMoverManager = playerMoverManager;
            _upMover = upMover;
            _downMover = downMover;
        }
        

        public void OnLeavingState()
        {
            active = false;
            SwipeManager.UpSwipeEvent -= SwipeUp;
            SwipeManager.DownSwipeEvent -= SwipeDown;
        }

        public void OnEnteringState()
        {
            active = true;
            SwipeManager.UpSwipeEvent += SwipeUp;
            SwipeManager.DownSwipeEvent += SwipeDown;
        }
        
        private void SwipeUp() => _playerMoverManager.StartCoroutine(MovePlayerUp());
        private void SwipeDown() => _playerMoverManager.StartCoroutine(MovePlayerDown());

        protected virtual IEnumerator MovePlayerUp()
        {
            throw new NotImplementedException();
        }

        protected virtual IEnumerator MovePlayerDown()
        {
            throw new NotImplementedException();
        }
    }
}