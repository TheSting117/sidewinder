using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Start()
    {
        //Unlocks the cursor so the player can use it
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayGame()
    {
        //loads the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //Quits the game
        Debug.Log("QUIT SUCCESSFUL");
        Application.Quit();
    }
}
