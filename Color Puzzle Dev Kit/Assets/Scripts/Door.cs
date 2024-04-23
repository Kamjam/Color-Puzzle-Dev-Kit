using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [Tooltip("This door's color")]
    public string doorColor;

    [Tooltip("Checks whether or not this door is the maze exit.")]
    public bool isExit;

    [Tooltip("This door's sprite, just for reference")]
    [SerializeField] private Sprite doorImage;

    //Ref. to the current slot script
    [Tooltip("The player's mini inventory slot")]
    CurrentSlot currentSlot;

    //Door text popup
    [Tooltip("The Popup Background image object")]
    public Image popupBG;
    [Tooltip("The Popup text object")]
    public TMP_Text popupText;
    [Tooltip("Checks whether or not the popup text is showing, DO NOT EDIT")]
    public bool popupEnabled;

    //Popup timer
    [Tooltip("Checks whether or not the timer started, DO NOT EDIT")]
    public bool timerStart = false;

    [Tooltip("The amount of seconds the time is going to count down, DO NOT EDIT")]
    [SerializeField] private float targetTime = 7.0f; //time in seconds

    [Tooltip("The amount of seconds the time is going to reset, DO NOT EDIT")]
    [SerializeField] private float maxTime = 7.0f; 

    [Tooltip("Checks whether or not this door denied the player, DO NOT EDIT.")]
    public bool wasDenied;

    // Start is called before the first frame update
    void Start()
    {
        popupBG.enabled = false;
        popupText.enabled = false;
    
        currentSlot = GameObject.Find("Current Dye").GetComponent<CurrentSlot>();
    }

    void Update()
    {
        //checks if the timer has started and tracks its progress
        if(timerStart)
        {
            //start countdown
            targetTime -= Time.deltaTime;

            if(targetTime <= 0.0f)
            {
                Debug.Log("Popup Timer has finished");
                timerStart = false;

                //disable the text popup
                disablePopup();
                targetTime = maxTime;
            }
        }
    }

    //enable the text popup
    public void enablePopup()
    {
        //enable bool
        popupEnabled = true;
        //enable text bg
        popupBG.enabled = true;

        //update the text
        popupText.text = "You can't go through here without the right dye";
        //enable texts
        popupText.enabled = true;

        Debug.Log("Door text is visible");

        //start the popup timer
        timerStart = true;
    }

    //disable the text popup
    public void disablePopup()
    {
        //disable everything
        popupBG.enabled = false;
        popupText.enabled = false;
        popupEnabled = false; 

        Debug.Log("Door text is no longer visible");
        
        wasDenied = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //checks for collision with player
        if(collision.gameObject.tag == "Player")
        {
            //checks if the player's tag is the same color as the door color
            if(currentSlot.playerColorTag == doorColor && isExit)
            {
                wasDenied = false;
                Destroy(gameObject);
                Debug.Log("Door was unlocked");

                //change scene to game over screen
                SceneManager.LoadScene("GameOver");
            }
            //if it matches, but not the exit door
            else if(currentSlot.playerColorTag == doorColor && !isExit)
            {
                wasDenied = false;
                Destroy(gameObject);
                Debug.Log("Door was unlocked");
            }
            //if they don't match, show a popup
            else if(currentSlot.playerColorTag != doorColor || (currentSlot.playerColorTag != doorColor && isExit))
            {
                wasDenied = true;
                enablePopup();

                Debug.Log("Door cannot be unlocked");
            }
        }
    }
}