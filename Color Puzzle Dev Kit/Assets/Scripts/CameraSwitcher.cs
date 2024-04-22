using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    //camera variables

    [Tooltip("The default camera")]
    public GameObject Camera1;
    
    [Tooltip("The secondary camera")]
    public GameObject Camera2;
    
    [Tooltip("Checks whether or not the cameras have been swapped, DO NOT EDIT")]
    public bool cameraSwitch = false;

    // Start is called before the first frame update
    void Awake()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        cameraSwitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If P key pressed switch the perspective
        if(Input.GetKeyDown(KeyCode.P))
        {
            //if false switch camera 1 with 2
            if(cameraSwitch == false)
            {
                Camera2.SetActive(true);
                Camera1.SetActive(false);

                cameraSwitch = true;
            }

            //otherwise switch back
            else if(cameraSwitch == true)
            {
                Camera1.SetActive(true);
                Camera2.SetActive(false);

                cameraSwitch = false;
            }
        }
    }
}