using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    //square prefab
    public GameObject spawnPrefab;

    //spawn sound
    public AudioSource spawnSound;

    void Start()
    {
        spawnSound = GetComponent<AudioSource>();
    }

    public void spawnSquare()
    {
        //play sound
        spawnSound.Play(0);
    
        //spawns the prefab to the right of the screen
        Instantiate(spawnPrefab, new Vector3(6, 4, 0), Quaternion.identity);
    }
}