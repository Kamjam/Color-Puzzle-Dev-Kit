using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [Tooltip("Checks whether or not the timer started, DO NOT EDIT")]
    public bool timerStart = false;
    [SerializeField] private float targetTime = 0.0f; //time in seconds

    [Tooltip("The timer text object")]
    public TMP_Text timer;

    // Start is called before the first frame update
    void Start()
    {
        timerStart = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //prints timer programs
        if(timerStart)
        {
            //convert the time to an int
            int seconds = (int)targetTime;

            displayTimer(targetTime);

            if(seconds >= 300)
            {
                Debug.Log("Timer's up! ");
                timerStart = false;
            }
        }
    }

    void Update()
    {
        //checks if the timer has started and tracks its progress
        if(timerStart)
        {
            //start countdown
            targetTime += Time.deltaTime;

            if(targetTime >= 300.0f)
            {
                Debug.Log("Timer has finished");
                timerStart = false;
            }
        }
    }

    void displayTimer(float timeToDisplay)
    {
        timer.enabled = true;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        
        string timeOut = string.Format("{0:00}:{1:00}", minutes, seconds);

        timer.text = "Elapse Time: " + timeOut;
        Debug.Log("Level Timer: " + timeOut);
    }
}