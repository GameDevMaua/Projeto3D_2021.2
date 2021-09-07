using System.Collections;

namespace Player.Movers
{
    public class JetPackMover : PlayerVerticalMover
    {
        public override void OnLeavingState()
        {
            base.OnLeavingState();
            PlayerEventManager.CarOutOfFuelEvent -= OnFuelEnded;
        }
        public override void OnEnteringState()
        {
            base.OnEnteringState();
            PlayerEventManager.CarOutOfFuelEvent += OnFuelEnded;
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