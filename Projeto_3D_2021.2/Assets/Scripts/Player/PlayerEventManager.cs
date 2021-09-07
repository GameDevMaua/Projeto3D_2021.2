using System;

namespace Player
{
    public static class PlayerEventManager
    {   
        public delegate void PlayerEventHandler();

        public static event PlayerEventHandler JetPackOutOfFuelEvent = () => {};
        public static event PlayerEventHandler CarOutOfFuelEvent = () => {};
        public static event PlayerEventHandler PlayerDiedEvent = () => {};
        public static event PlayerEventHandler HitLateralObstacleEvent = () => {};
        public static event PlayerEventHandler CarHitObstacleEvent = () => {};

        public static event PlayerEventHandler FixedUpdateEvent = () => {};

        public static event PlayerEventHandler StartAnimationMoveEvent = () => {};
        public static event PlayerEventHandler EndAnimationMoveEvent = () => {};
        
        
        
        public static void InvokeJetPackOutOfFuelEvent() => JetPackOutOfFuelEvent.Invoke();
        public static void InvokeCarOutOfFuelEvent() => CarOutOfFuelEvent.Invoke();
        public static void InvokePlayerDiedEvent() => PlayerDiedEvent.Invoke();
        public static void InvokeHitLateralObstacleEvent() => HitLateralObstacleEvent.Invoke();
        public static void InvokeCarHitObstacleEvent() => CarHitObstacleEvent.Invoke();
        
        public static void InvokeFixedUpdateEvent() => FixedUpdateEvent.Invoke();
        
        public static void InvokeStartAnimationMoveEvent() => StartAnimationMoveEvent.Invoke();
        public static void InvokeEndAnimationMoveEvent() => EndAnimationMoveEvent.Invoke();

    }
}