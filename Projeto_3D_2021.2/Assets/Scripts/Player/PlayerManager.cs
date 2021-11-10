
using UnityEngine;

namespace Player
{
    public class PlayerManager : Singleton<PlayerManager>{
        public GameObject character;
        
        private static bool _isPlayerMoving = true;
        private static void StartPlayerMove() => _isPlayerMoving = true;
        private static void EndPlayerMove() => _isPlayerMoving = false;
        public static bool CanPlayerMove() => _isPlayerMoving;

        private void OnEnable()
        {
            PlayerEventManager.StartAnimationMoveEvent += StartPlayerMove;
            PlayerEventManager.EndAnimationMoveEvent += EndPlayerMove;
        }

        private void OnDisable()
        {
            PlayerEventManager.StartAnimationMoveEvent -= StartPlayerMove;
            PlayerEventManager.EndAnimationMoveEvent -= EndPlayerMove;
        }
    }
}