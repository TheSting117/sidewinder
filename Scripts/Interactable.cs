using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    //Allows selection of the interaction key
    public KeyCode interactKey;
    public UnityEvent interactAction;

    private void Update()
    {
        //if player is in range of trigger collision and the interact key is pressed
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                //executes unity editor defined function
                interactAction.Invoke();
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        //if player enters trigger collision
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        //if player exits trigger collision
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
