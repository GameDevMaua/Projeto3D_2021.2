namespace Player
{
    public interface IState
    {
        void OnLeavingState();
        void OnEnteringState();
    }
}