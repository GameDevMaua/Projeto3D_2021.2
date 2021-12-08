using System;
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

        _playerControls.Touch.Jetpack.performed += ctx => EndTouchPrimary(ctx);
        
    }

    public struct TouchPositionInfo
    {
        public Vector2 lastFrameTouchPosition;
        public Vector2 currentFrameTouchPosition;
        public Vector2 deltaTouchPosition;
        public float deltaTimeTouchPosition;
    }

    public TouchPositionInfo touchPosition;
    private void UpdateTouchPrimary(InputAction.CallbackContext context)
    {
        touchPosition.currentFrameTouchPosition = _playerControls.Touch.PrimaryPosition.ReadValue<Vector2>();
        touchPosition.deltaTouchPosition        = touchPosition.currentFrameTouchPosition - touchPosition.lastFrameTouchPosition;
        touchPosition.deltaTimeTouchPosition    = (float)context.time;
        touchPosition.lastFrameTouchPosition    = touchPosition.currentFrameTouchPosition;
    }
    
    private void StartTouchPrimary(InputAction.CallbackContext context) {
        if (OnStartTouch != null) OnStartTouch(_playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(), (float)context.startTime);
    }
    
    private void EndTouchPrimary(InputAction.CallbackContext context) {
        if (OnEndTouch != null) OnEndTouch(_playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(), (float)context.time);
    }

 }
