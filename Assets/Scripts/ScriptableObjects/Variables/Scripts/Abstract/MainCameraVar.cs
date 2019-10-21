using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MainCameraVar : ScriptableObject
{
    #if UNITY_EDITOR
        [TextArea(3,10)]
        public string DeveloperDescription = "";
    #endif

    public Camera camera;

    public void SetValue(Camera camera) {
        this.camera = camera;
    }
}
