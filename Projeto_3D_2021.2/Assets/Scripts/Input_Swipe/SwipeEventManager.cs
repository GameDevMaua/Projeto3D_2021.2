
namespace Input_Swipe
{
    public static class SwipeEventManager //: Singleton<SwipeManager>
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