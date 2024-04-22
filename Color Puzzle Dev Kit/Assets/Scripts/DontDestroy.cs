using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //array has to be big enough to store all the objects that you want to stay the same across different scenes
    private static GameObject[] persistentObjs = new GameObject[10]; 
    
    [Tooltip("This current object's index in the array, 0 is first, 1 is second, etc.")]
    public int objIndex;

    void Awake()
    {
        //if this array is empty add the current object
        if(persistentObjs[objIndex] == null)
        {
            persistentObjs[objIndex] = gameObject;
            //don't destroy when the scene loads
            DontDestroyOnLoad(gameObject);
        }

        //if there is a duplicate game object in the array, delete it
        else if (persistentObjs[objIndex] != gameObject)
        {
            Destroy(gameObject);
        }
    }
}