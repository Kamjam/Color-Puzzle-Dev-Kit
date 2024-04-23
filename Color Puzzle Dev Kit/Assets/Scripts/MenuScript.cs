using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Play button is clicked
    public void DemoGameButton()
    {
        SceneManager.LoadScene("Color Puzzle - Demo");
    }
    
    public void StartGameButton()
    {
        SceneManager.LoadScene("Level One");
    }

    //Retry Button is clicked after Game Over
    public void RetryGameButton()
    {
        //could be set to load the last completed level
        SceneManager.LoadScene("Color Puzzle - Demo");
    }

    // Exit button is clicked
    public void ExitGameButton()
    {
        Application.Quit();
    }
}