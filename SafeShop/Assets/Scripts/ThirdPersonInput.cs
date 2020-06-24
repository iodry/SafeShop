using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonInput : MonoBehaviour
{
    public FixedJoystick fixedJoystick;
    //public FixedJoystick camJoystick;
    public FixedTouchField touchField;
    public FixedButton aButton;
    protected ThirdPersonUserControl control;
    protected float camAngle;
    protected float camAngleSpeed = 0.2f;
    public Vector3 offset = new Vector3(0f, 2f, -3f);

    public Inventory inventory;
    
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
        //control.m_Jump = aButton.Pressed;

        camAngle += touchField.TouchDist.x * camAngleSpeed;
        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(camAngle, Vector3.up) * offset;
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up-Camera.main.transform.position, Vector3.up);

        /*var input = new Vector3(LeftJoystick.inputVector.x, 0, LeftJoystick.inputVector.y);

        var vel = Quaternion.AngleAxis(CameraAngleY + 180, Vector3.up) * input * 5f;
        transform.rotation = Quaternion.AngleAxis(CameraAngleY + Vector3.SignedAngle(Vector3.forward, input.normalized + Vector3.forward * 0.0001f, Vector3.up) + 180, Vector3.up);
        Rigidbody.velocity = new Vector3(vel.x, Rigidbody.velocity.y, vel.z);

        CameraAngleY += TouchField.TouchDist.x * CameraAngleSpeed;
        CameraPosY = Mathf.Clamp(CameraPosY - TouchField.TouchDist.y * CameraPosSpeed, 0, 5f);

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngleY, Vector3.up) * new Vector3(0, CameraPosY, 4);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);*/
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponentInParent<IInventoryItem>();
        if (item!= null)
        {
            inventory.AddItem(item);
            Debug.Log("Collider input");
        }
    }
}
