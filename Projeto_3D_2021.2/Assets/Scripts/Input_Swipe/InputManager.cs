using UnityEngine;
using UnityEngine.InputSystem;


[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    
    #endregion
        
    private PlayerControls _playerControls;
    public Camera _mainCamera; 

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _playerControls.Enable(); 
    }
    
    private void OnDisable()
    {
        _playerControls.Disable(); 
    }

    void Start()
    {
        _playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        _playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context) {
        if (OnStartTouch != null) OnStartTouch(_playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(), (float)context.startTime);
    }
    
    private void EndTouchPrimary(InputAction.CallbackContext context) {
        if (OnEndTouch != null) OnEndTouch(_playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(), (float)context.time);
    }

    // private void Tap(InputAction.CallbackContext context) {
    //     if(OnTap != null) 
    // }

 }
