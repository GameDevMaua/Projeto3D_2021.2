using Input_Swipe;
using Player;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float minimumDistance = .2f;
    [SerializeField] private float maximumTime = 1f;
    [SerializeField, Range(0f, 1f)] private float directionThreshold = .9f;

    private InputManager _inputManager;

    private Vector2 _startPosition;
    private float _startTime;
    private Vector2 _endPosition;
    private float _endTime;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
    }

    private void OnEnable(){
        _inputManager.OnStartTouch += SwipeStart;
        _inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable(){
        _inputManager.OnStartTouch -= SwipeStart;
        _inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time){
        _startPosition = position;
        _startTime = time;
    }
 
    private void SwipeEnd(Vector2 position, float time){
        _endPosition = position;
        _endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe(){
        if (!PlayerManager.CanPlayerMove())
            return;
        
        DoDebug();
        var dir = _endPosition - _startPosition;
        var deltaTime = _endTime - _startTime;
        if (dir.magnitude >= minimumDistance &&  deltaTime <= maximumTime){
            SwipeDirection(dir.normalized);
        }
    }

    private void DoDebug(){
        var dir = _endPosition - _startPosition;
        
        // Debug.Log("Swipe Detected");
        if (dir.magnitude >= minimumDistance && _endTime - _startTime <= maximumTime)
        {
            Debug.DrawLine(_startPosition, _endPosition, Color.green, 5f);
        }else if (!(dir.magnitude >= minimumDistance))
        {
            Debug.DrawLine(_startPosition, _endPosition, Color.red, 5f);
        }else if (_endTime - _startTime <= maximumTime)
        {
            Debug.DrawLine(_startPosition, _endPosition, Color.yellow, 5f);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            // Debug.Log("Swipe Up");
            SwipeEventManager.UpSwipeInvoke();
            
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            // Debug.Log("Swipe Down");
            SwipeEventManager.DownSwipeInvoke();
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            // Debug.Log("Swipe Left");
            SwipeEventManager.LeftSwipeInvoke();
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            // Debug.Log("Swipe Right");
            SwipeEventManager.RightSwipeInvoke();
        }
    }
}