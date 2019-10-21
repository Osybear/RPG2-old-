using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraSetter : MonoBehaviour
{
    public MainCameraVar mainCamera;

    private void Awake() {
        mainCamera.SetValue(GetComponent<Camera>());    
    }

    private void OnDisable() {
        mainCamera.camera = null;
    }
}
