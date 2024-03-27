using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    //function to reset the square's color
    public void resetButton()
    {
        //Get the current scene
        Scene scene = SceneManager.GetActiveScene(); 
        
        //Reload the current scene
        SceneManager.LoadScene(scene.name);
    }
}