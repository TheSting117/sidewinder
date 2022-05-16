using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataPadLogic : MonoBehaviour
{
    //creates a referencable instance of the UserInterfaceUpdate script so that the retrieved count can be increased in that script
    public UserInterfaceUpdate updateUI;
    //Gets the audio clip that will be played when the datapad is picked up
    public AudioClip clip;
    //Gets the audio source that the audio clip will be played through
    public AudioSource audioSource;
    //Gets this gameobject for referencing
    public GameObject self;
    


    public void DatapadPickup()
    {
        //plays the pickup sound effect through the desired audio source
        audioSource.PlayOneShot(clip);
        //Removes the datapad from the enviroment
        Destroy(self);
        //Calls the retrieveUpdate function to increase the count of datapads retrieved
        updateUI.retrieveUpdate();

    }


}
