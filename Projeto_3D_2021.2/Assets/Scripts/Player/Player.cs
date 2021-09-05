using JetBrains.Annotations;
using UnityEngine;

namespace Player
{
    public class PlayerMoverManager : MonoBehaviour
    {
        private PlayerHorizontalMover _currentPlayerHorizontalMover;
        private PlayerVerticalMover _currentPlayerVerticalMover;
        /*todo: make a bigger player class that hold info about the player(singleton) or can be a game manager
         that can hold if the player is in the middle of a animation etc, makes the input system not invoke 
         if there is something in the way
        */
        //private Player _player;
        private readonly Vector3 _rightVector3;

        private PlayerVerticalMover _carLayer;
        private PlayerVerticalMover _airLayer;
        private PlayerVerticalMover _jetPackLayer;
        private void Awake()
        {
            _carLayer = new PlayerVerticalMover();
            _airLayer = new PlayerVerticalMover();
            _jetPackLayer = new PlayerVerticalMover();
        }

        private void Start()
        {
            _carLayer.InjectInfo(this,_airLayer,null);
            _airLayer.InjectInfo(this,_carLayer,_jetPackLayer);
            _jetPackLayer.InjectInfo(this,null,_airLayer);
            
            
        }

        //todo: rename this methode and make this work with the lateral movement
        public void ChangePlayerMover([NotNull] PlayerHorizontalMover newPlayerHorizontalMover)
        {
            _currentPlayerHorizontalMover?.OnLeavingState();
            _currentPlayerHorizontalMover = newPlayerHorizontalMover;
            newPlayerHorizontalMover.OnEnteringState();
        }
    }
}