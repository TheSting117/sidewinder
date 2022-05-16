using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterfaceUpdate : MonoBehaviour
{
    //Defines the Image that will be updated when a datapad is picked up
    public Image datapadTracker;
    //Defines an array of sprites that can be selected to change the Image's sprite to
    public Sprite[] sprites;
    //Defines the UI element that will display when the level is complete
    public GameObject completeLevelUI;
    //How many datapads have been found
    public int retrieveCount = 0;

    void Update()
    {
        //Update the Image's Sprite so that its representative of how many datapads have been picked up
        UpdateSprite();
    }

    //Increases retrieved datapad count
    public void retrieveUpdate()
    {
        retrieveCount += 1;
    }

    public void UpdateSprite()
    {
        if (retrieveCount == 0)
        {
            datapadTracker.sprite = sprites[0];
        }
        if (retrieveCount == 1)
        {
            datapadTracker.sprite = sprites[1];
        }
        if (retrieveCount == 2)
        {
            datapadTracker.sprite = sprites[2];
        }
        if (retrieveCount >= 3)
        {
            datapadTracker.sprite = sprites[3];
            CompleteLevel();
        }
    }
    //Sets the completeLevelUI to active and then calls the mission complete scene
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Invoke("MissionCompleteScene", 3.0f);
    }
    //Loads the next scene
    public void MissionCompleteScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
