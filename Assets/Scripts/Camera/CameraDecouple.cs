﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDecouple : MonoBehaviour
{
    private void Start() {
        transform.SetParent(null);
    }
}
