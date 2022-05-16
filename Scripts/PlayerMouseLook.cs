using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
    //Base Sensitivity
    public float mouseSense = 100.0f;
    //Player
    public Transform playerBody;
    
    float xRotation = 0f;

    void Start()
    {
        //Locks the cursor 
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
       
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;
        xRotation -= mouseY;
        //Clamps mouse movement so the user cannot looking infinitely up or down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        
    }
}
