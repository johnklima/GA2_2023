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
    [SerializeField] float mouseSensitivity = 5;
    [SerializeField] Vector2 pitchMinMax = new Vector2(-45, 45);
    [SerializeField] float rotationSmoothTime = .12f;
    [SerializeField] Transform Bee;

    [Header("Cursor Check")]
    [SerializeField] bool lockCursor;

    
    Vector3 rotationSmoothVelocity;  //required for the method, not actualy important
    Vector3 currentRotation;         //keep track of our current in Eulers

    //the usual for a flight sim
    float yaw;
    float pitch;
    float roll;

    float initialSensitivity;
    float coupleTimer = -1;

    // Start is called before the first frame update
    void Start()
    {

        initialSensitivity = mouseSensitivity;

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
        //always resititute back to original mouse sensitivity (usually changed in collision)
        if(initialSensitivity != mouseSensitivity)
        {
            mouseSensitivity = Mathf.Lerp(mouseSensitivity, initialSensitivity, Time.deltaTime * 0.1f);
            if(Mathf.Abs(initialSensitivity - mouseSensitivity) < 0.01f)
            {
                mouseSensitivity = initialSensitivity;
               
            }
        }

        if (coupleTimer > 0 && Time.time - coupleTimer > 0.03f)
            Couple();

        CameraMovement();

    }

    void CameraMovement()
    {
        float x = Input.GetAxis("Mouse X") * mouseSensitivity;
        x = Mathf.Clamp(x, -3, 3);

        yaw += x;

        float y = Input.GetAxis("Mouse Y") * mouseSensitivity;
        y = Mathf.Clamp(y, -3, 3);

        pitch -= y;

        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

    }
    public void SetMouseSensitivity(float sensitivity)
    {
        initialSensitivity = mouseSensitivity;
        mouseSensitivity = sensitivity;

    }
    public void Couple()
    {
        coupleTimer = -1;
        Bee.SetParent(this.transform);
    }
    public void DeCouple()
    {
        coupleTimer = Time.time;
        Bee.SetParent(null);
    }



}
