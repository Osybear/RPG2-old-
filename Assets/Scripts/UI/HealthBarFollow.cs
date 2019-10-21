using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{   
    public MainCameraVar mainCamera;
    public Transform target;
    public Vector3 offset;

    private void FixedUpdate() {
        transform.position = mainCamera.camera.WorldToScreenPoint(target.position + offset);
    }
}
