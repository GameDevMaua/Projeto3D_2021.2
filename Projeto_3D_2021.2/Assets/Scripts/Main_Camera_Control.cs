using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Main_Camera_Control : MonoBehaviour{
    private CinemachineVirtualCamera _virtualCamera;
    
    private void Start() {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnEnable() {
        // Class.Event += StartCameraCoroutine(intensity, frequency, timeInSeconds);
    }

    private void OnDisable() {
        // Class.Event -= StartCameraCoroutine(intensity, frequency, timeInSeconds);
    }

    private void StartShakeCameraCoroutine(float intensity, float frequency, float timeInSeconds) {
        StartCoroutine(ShakeCamera(intensity, frequency, timeInSeconds));
    }

    IEnumerator ShakeCamera(float intensity, float frequency, float timeInSeconds) {
        CinemachineBasicMultiChannelPerlin shakeParemeters =
            _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        shakeParemeters.m_AmplitudeGain = intensity;
        shakeParemeters.m_FrequencyGain = frequency;

        yield return new WaitForSeconds(timeInSeconds);
        
        shakeParemeters.m_AmplitudeGain = 0f;
        shakeParemeters.m_FrequencyGain = 0f;       

    }
}
