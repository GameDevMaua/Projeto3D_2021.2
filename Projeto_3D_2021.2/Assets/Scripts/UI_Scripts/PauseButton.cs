using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseButton : MonoBehaviour{
    private bool _gameIsPaused = false;

    [SerializeField] private UnityEvent OnGamePaused;
    [SerializeField] private UnityEvent OnGameResumed;
    
    public void PauseAndResumeGame() {
        if (!_gameIsPaused) { //Pause Game
            Time.timeScale = 0f;
            OnGamePaused?.Invoke();
        }
        else { //Resume Game
            Time.timeScale = 1f;
            OnGameResumed?.Invoke();
        }

        _gameIsPaused = !_gameIsPaused;

    }
}
