/*
 * (c) copyright 2023 John Klima
 * Free for non-commercial use
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCamera : MonoBehaviour
{

    [Header("Camera Settings")]
    [Range(0f, 20f)]
    public float mouseSensitivity = 10;
    public Vector2 pitchMinMax = new Vector2(-40, 85);
    public float rotationSmoothTime = .12f;

    [Header("Cursor Check")]
    public bool lockCursor;

    
    Vector3 rotationSmoothVelocity;  //required for the method, not actualy important
    Vector3 currentRotation;         //keep track of our current in Eulers

    //the usual for a flight sim
    float yaw;
    float pitch;
    float roll;


    // Start is called before the first frame update
    void Start()
    {
        //typical fps, though this is actually 3rd
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        pitch = 0;
        yaw = 0;
        roll = 0;
    }

    // LateUpdate is called once per frame, after everything else
    void LateUpdate()
    {
        CameraMovement();

    }

    void CameraMovement()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
    
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

    }
    
}
