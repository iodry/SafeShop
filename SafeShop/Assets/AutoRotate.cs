﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    private float ySpeed = 50f; 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(
     0,
     ySpeed * Time.deltaTime,
     0
);
    }
}
