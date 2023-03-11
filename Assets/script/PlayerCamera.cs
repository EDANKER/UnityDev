using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sentX;
    public float sentY;

    public Transform orientation;

    private float xRoration;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sentX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sentY;

        yRotation += mouseX;

        xRoration -= mouseY;
        xRoration = Mathf.Clamp(xRoration, -90f, 90f);
        
        if (yRotation < 90f)
        {
            
            
        }
       
        
        transform.rotation = Quaternion.Euler(xRoration, yRotation,0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
