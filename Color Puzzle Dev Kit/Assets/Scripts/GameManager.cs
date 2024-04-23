using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    [Tooltip("The location text canvas")]
    public GameObject locationContainer;
    
    [Tooltip("The location text")]
    public TMP_Text locationText;
    
    [Tooltip("This object's audio source")]
    public AudioSource bgm;

    //notation for adding more scenes into the array: new string[4] {"B1", "F1", "F2", "A1"};
    //adjust the number inside new string[_] to the correct array length if you add more levels 
    string[] floors = new string[1] {"Demo"};
    //should be offset by one since it doesn't count start/game over scenes
    /*
        In Build settings:
        SceneIndex 1 = Demo, [0]    
        SceneIndex 2 = [1] 
        SceneIndex 3 = [2]
        SceneIndex 4 = [3]
    */
    [SerializeField] public int currentScene = 0;

    void Start()
    {
        bgm = GetComponent<AudioSource>();

        locationContainer = GameObject.Find("UI Canvas");

        //makes sure the text is set
        if(locationText == null)
        {
            //find the container for the text and set the text by getting from the container
            locationText = locationContainer.GetComponent<TMP_Text>();
        }

        currentScene = 0;
        checkScene();
    }

    void Update()
    {
        checkScene();
        //uncomment for adding background music
        //playBGM();

        //quit application any time
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    //forces unity to set the text objects because it resets every scene change
    public void setTextObjects()
    {
        locationContainer = GameObject.Find("Location Text Canvas");

        if(locationText == null)
        {
            locationText = locationContainer.GetComponent<TMP_Text>();
        }
    }

    //for playing background music, make sure this object has an audio source
    public void playBGM()
    {
        //while the scenes stay on the dungeon levels play the background music
        while(currentScene <= 0 && currentScene >= 3)
        {
            //Play sound and animation
            bgm.Play(0);
        }
    }

    //check what level the player is on
    public void checkScene()
    {
        //check the current scene name and change to the next one
        //names should match the scene names in the scenes folder
        if(SceneManager.GetActiveScene().name == "Color Puzzle - Demo")
        {
            currentScene = 0;
            updateLocation(currentScene);
            setTextObjects();
        }
        //uncomment for adding new scenes to the array, make sure add these scenes in the build settings
        /*else if(SceneManager.GetActiveScene().name == "Level  One")
        {
            currentScene = 1;
            updateLocation(currentScene);
            setTextObjects();
        }*/
    }

    //function to update the location text when the scene changes to the next level
    public void updateLocation(int floorIndex)
    {
        locationText.text = "You are Here: " + floors[floorIndex]; 
    }
}