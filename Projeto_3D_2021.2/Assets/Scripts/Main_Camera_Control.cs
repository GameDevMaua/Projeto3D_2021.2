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

    [ContextMenu("Test Shake")]
    public void TestShake()
    {
        StartShakeCameraCoroutine(1f,3f,.5f);
    }

    private void StartShakeCameraCoroutine(float intensity, float frequency, float timeInSeconds) {
        StartCoroutine(ShakeCamera(intensity, frequency, timeInSeconds));
    }

    IEnumerator ShakeCamera(float intensity, float frequency, float timeInSeconds) {
        CinemachineBasicMultiChannelPerlin shakeParemeters =
            _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        print(shakeParemeters);
        
        shakeParemeters.m_AmplitudeGain = intensity;
        shakeParemeters.m_FrequencyGain = frequency;

        float resolution = 10;
        for (float i = 0; i < resolution; i++)
        {
            yield return new WaitForSeconds(timeInSeconds/resolution);

            var value = 1f - i / (resolution - 1);
            shakeParemeters.m_AmplitudeGain = value;
            shakeParemeters.m_FrequencyGain = value;
        }
    }
}
