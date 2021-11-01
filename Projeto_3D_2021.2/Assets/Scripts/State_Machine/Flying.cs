
namespace State_Machine{
    public class Flying : BaseState{

        public Flying(StateManager stateManager) : base(stateManager) {
        }

        public override void OnExecuteState() {
            
        }

        public override void OnStateEnter() {
            base.OnStateEnter();
        }

        public override void OnStateLeaving() {
            base.OnStateLeaving();
        }

        public override void OnSwipeDown() {
            _stateManager.ChangeCurrentState(_stateManager.fallingState);
        }

        public override void OnSwipeLeft() {
            
        }

        public override void OnSwipeRight() {
            
        }
    }
}