
using Input_Swipe;
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

    private void OnEnable()
    {
        _inputManager.OnStartTouch += SwipeStart;
        _inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        _inputManager.OnStartTouch -= SwipeStart;
        _inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        _startPosition = position;
        _startTime = time;
    }
 
    private void SwipeEnd(Vector2 position, float time)
    {
        _endPosition = position;
        _endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(_startPosition, _endPosition) >= minimumDistance &&
            (_endTime - _startTime) <= maximumTime)
        {
                Debug.Log("Swipe Detected");
                Debug.DrawLine(_startPosition, _endPosition, Color.green, 5f);
                Vector3 direction = _endPosition - _startPosition;
                Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
                SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            Debug.Log("Swipe Up");
            SwipeManager.UpSwipeInvoke();
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("Swipe Down");
            SwipeManager.DownSwipeInvoke();
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            Debug.Log("Swipe Left");
            SwipeManager.LeftSwipeInvoke();
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            Debug.Log("Swipe Right");
            SwipeManager.RightSwipeInvoke();
        }
    }



    }    