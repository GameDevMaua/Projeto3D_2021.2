using System.Collections;

namespace Player.Movers
{
    public class InCarMover : PlayerVerticalMover
    {
        public override void OnLeavingState()
        {
            base.OnLeavingState();
            PlayerEventManager.CarHitObstacleEvent -= OnHittingObstacle;
            PlayerEventManager.CarOutOfFuelEvent -= OnFuelEnded;
        }
        public override void OnEnteringState()
        {
            base.OnEnteringState();
            PlayerEventManager.CarHitObstacleEvent += OnHittingObstacle;
            PlayerEventManager.CarOutOfFuelEvent += OnFuelEnded;
        }
        private void OnHittingObstacle()
        {
            throw new System.NotImplementedException();
        }
        private void OnFuelEnded()
        {
            throw new System.NotImplementedException();
        }
        protected override IEnumerator OnSwipeUp()
        {
            throw new System.NotImplementedException();
        }
        protected override IEnumerator OnSwipeDown()
        {
            throw new System.NotImplementedException();
        }
    }
}