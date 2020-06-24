using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    
    public float rotationRate = 360;
    public float moveSpeed = 1;

    private Rigidbody rb;
    public CharacterController controller;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        Vector3 move = turnAxis * transform.right + moveAxis * transform.forward;

        controller.Move(move * moveSpeed * Time.deltaTime);
       

    }

/*    private void FixedUpdate()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);
        ApplyInput(moveAxis, turnAxis);
    }*/

    private void ApplyInput(float moveInput,
                            float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);
    }

    private void Move(float input)
    {
        //Move
        rb.AddForce(transform.forward * input * moveSpeed, ForceMode.Force);
        //transform.Translate(Vector3.forward * input * moveSpeed);
    }
    private void Turn(float input)
    {
        //Turn
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
