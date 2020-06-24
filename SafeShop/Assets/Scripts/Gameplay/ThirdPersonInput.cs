using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonInput : MonoBehaviour
{
    public FixedJoystick fixedJoystick;
    private ThirdPersonUserControl control;
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<ThirdPersonUserControl>();
    }

    // Update is called once per frame
    void Update()
    {
        control.hInput = fixedJoystick.Horizontal;
        control.vInput = fixedJoystick.Vertical;
    }
}
