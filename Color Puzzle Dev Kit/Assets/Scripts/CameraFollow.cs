using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [Tooltip("The object that the camera needs to follow")]
    [SerializeField] public GameObject target;

    // Update is called once per frame
    void Update()
    {
        //Camera follows based on the target position
        transform.position = target.transform.position + new Vector3 (0, 1, -10);
    }
}