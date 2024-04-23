using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DyeSpawner : MonoBehaviour
{
    [Tooltip("This dye machine object, which is used to greyscale after activation")]
    public GameObject thisMachine;

    [Tooltip("A dye prefab object from the prefab folder")]
    [SerializeField] public GameObject dyePrefabSpawn;

    [Tooltip("The sound source within this dye machine object")]
    public AudioSource spawnSound;

    //Machine text popup
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

    void Start()
    {
        popupBG.enabled = false;
        popupText.enabled = false;

        spawnSound = GetComponent<AudioSource>();
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
            }
        }
    }
    
    public void InstantiateDye(Vector3 spawnPosition)
    { 
        //play sound
        spawnSound.Play(0);
        
        //Spawn dye
        GameObject dyeGameObj = Instantiate(dyePrefabSpawn, spawnPosition, Quaternion.identity);

        //Add force so the items slide into a random direction when they spawn
        float dropForce = 5f;
        Vector2 dropDirection = new Vector2(0, Random.Range(1.5f, 5.5f));

        dyeGameObj.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
    }

    //enable the text popup
    public void enablePopup()
    {
        //enable bool
        popupEnabled = true;
        //enable text bg
        popupBG.enabled = true;

        //update the text
        popupText.text = "Press Space to Dispense Dye.";
        //enable texts
        popupText.enabled = true;

        Debug.Log("Vending Machine text is visible");

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

        Debug.Log("Vending Machine text is no longer visible");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enablePopup();

            if(Input.GetKeyDown("space"))
            {            
                InstantiateDye(transform.position);
            
                //ignore colliders after spawning dye
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                gameObject.GetComponent<Collider2D>().isTrigger = true;

                //greyscale the machine so it looks deactivated
                thisMachine.GetComponent<SpriteRenderer>().color = Color.grey;
            }
        }
    }
}