using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    //camera variables
    public GameObject MainCamera;
    public GameObject FollowCamera;
    public bool cameraSwitch = false;

    // Start is called before the first frame update
    void Awake()
    {
        MainCamera.SetActive(true);
        FollowCamera.SetActive(false);
        cameraSwitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If P key pressed switch the perspective
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(cameraSwitch == false)
            {
                FollowCamera.SetActive(true);
                MainCamera.SetActive(false);

                cameraSwitch = true;
            }
            else if(cameraSwitch == true)
            {
                MainCamera.SetActive(true);
                FollowCamera.SetActive(false);

                cameraSwitch = false;
            }
        }
    }
}