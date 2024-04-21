using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;

    public WheelCollider FrontLeftWheelCollider;
    public WheelCollider FrontRightWheelCollider;
    public WheelCollider RearLeftWheelCollider;
    public WheelCollider RearRightWheelCollider;
    public Transform FrontLeftWheelTransform;
    public Transform FrontRightWheelTransform;
    public Transform RearLeftWheelTransform;
    public Transform RearRightWheelTransform;
    public Rigidbody Car_rigidBody;

    public float maxSteeringAngle = 30f;
    public float motorForce = 1000f;
    public float brakeForce = 5f;

 
    private void Update(){
    }


    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        FrontLeftWheelCollider.steerAngle = steerAngle;
        FrontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        RearLeftWheelCollider.motorTorque = verticalInput * motorForce;
        RearRightWheelCollider.motorTorque = verticalInput * motorForce;

        brakeForce = isBreaking ? 3000f : 0f;
        FrontLeftWheelCollider.brakeTorque = brakeForce;
        FrontRightWheelCollider.brakeTorque = brakeForce;
        RearLeftWheelCollider.brakeTorque = brakeForce;
        RearRightWheelCollider.brakeTorque = brakeForce;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(FrontLeftWheelCollider, FrontLeftWheelTransform);
        UpdateWheelPos(FrontRightWheelCollider, FrontRightWheelTransform);
        UpdateWheelPos(RearLeftWheelCollider, RearLeftWheelTransform);
        UpdateWheelPos(RearRightWheelCollider, RearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }

}