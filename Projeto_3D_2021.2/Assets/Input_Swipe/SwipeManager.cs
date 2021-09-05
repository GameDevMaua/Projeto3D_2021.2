using System;
using System.Runtime.CompilerServices;

namespace Input_Swipe
{
    public class SwipeManager : Singleton<SwipeManager>
    {
        public delegate void SwipeEventHandler();
        
        public static event SwipeEventHandler LeftSwipeEvent = () => {};
        public static event SwipeEventHandler RightSwipeEvent = () => {};
        public static event SwipeEventHandler UpSwipeEvent = () => {};
        public static event SwipeEventHandler DownSwipeEvent = () => {};

        public static void LeftSwipeInvoke() => LeftSwipeEvent?.Invoke();
        public static void RightSwipeInvoke() => RightSwipeEvent?.Invoke();
        public static void UpSwipeInvoke() => UpSwipeEvent?.Invoke();
        public static void DownSwipeInvoke() => DownSwipeEvent?.Invoke();
    }
}