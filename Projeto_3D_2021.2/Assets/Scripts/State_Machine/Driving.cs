
namespace State_Machine{
    public class Driving : BaseState{

        public Driving(StateManager stateManager) : base(stateManager) {
            
        }
        
        public override void OnExecuteState() {
            
        }

        public override void OnStateEnter() {
            base.OnStateEnter();
        }

        public override void OnStateLeaving() {
            base.OnStateLeaving();
        }

        public override void OnSwipeUp() {
            //todo:Verificar se alterar para o estado caindo é a melhor opção
            _stateManager.ChangeCurrentState(_stateManager.fallingState);
        }

        public override void OnSwipeLeft() {
            
        }

        public override void OnSwipeRight() {
      
        }
    }
}