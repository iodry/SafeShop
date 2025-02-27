﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonInput : MonoBehaviour
{
    public FloatingJoystick floatingJoystick;
    private ThirdPersonUserControl control;
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<ThirdPersonUserControl>();
    }

    // Update is called once per frame
    void Update()
    {
        control.hInput = floatingJoystick.Horizontal;
        control.vInput = floatingJoystick.Vertical;
    }
}
