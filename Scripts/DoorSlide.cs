using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlide : MonoBehaviour
{
    //initialises transform data of the left and right doors
    public Transform leftDoor;
    public Transform rightDoor;
    //initialises 2 lights 
    public Light outerLight = null;
    public Light innerLight = null;
    //initialises Vector3s that will be used to store position data 
    private Vector3 initialLeftDoor;
    private Vector3 initialRightDoor;
    private Vector3 doorDirection;
    //Defines the movement direction of the doors
    public enum Direction { X, Y, Z };
    public Direction directionType = Direction.Y;
    //Defines the speed that the doors open
    public float speed = 2.0f;
    //Defines how for the doors will move
    public float openDistance = 2.0f;
    //Used to make the door movement look animated
    private float point = 0.0f;
    //Deifnes whether the doors are opening or not
    private bool opening = false;

    void Update()
    {
        // Direction selection
        if (directionType == Direction.X)
        {
            doorDirection = Vector3.right;
        }
        else if (directionType == Direction.Y)
        {
            doorDirection = Vector3.up;
        }
        else if (directionType == Direction.Z)
        {
            doorDirection = Vector3.back;
        }

        // If opening
        if (opening)
        {
            point = Mathf.Lerp(point, 1.0f, Time.deltaTime * speed);
        }
        else
        {
            point = Mathf.Lerp(point, 0.0f, Time.deltaTime * speed);
        }

        // Move doors
        if (leftDoor)
        {
            leftDoor.localPosition = initialLeftDoor + (doorDirection * point * openDistance);
        }

        if (rightDoor)
        {
            rightDoor.localPosition = initialRightDoor + (-doorDirection * point * openDistance);
        }
    }

    //Record initial positions
    void Start()
    {

        if (leftDoor)
        {
            initialLeftDoor = leftDoor.localPosition;
        }

        if (rightDoor)
        {
            initialRightDoor = rightDoor.localPosition;
        }
    }

    //Open doors trigger
    void OnTriggerEnter(Collider other)
    {
        opening = true;

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        outerLight.color = Color.green;
        innerLight.color = Color.green;
    }

    //Close doors trigger
    void OnTriggerExit(Collider other)
    {
        opening = false;

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        outerLight.color = Color.red;
        innerLight.color = Color.red;
    }


    
    
}

