using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyeSpawner : MonoBehaviour
{
    
    [Tooltip("A dye prefab object from the prefab folder")]
    [SerializeField] public GameObject dyePrefabSpawn;

    [Tooltip("The sound source within this dye machine object")]
    public AudioSource spawnSound;

    void Start()
    {
        spawnSound = GetComponent<AudioSource>();
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

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Input.GetKeyDown("space"))
        {
            InstantiateDye(transform.position);
            
            //ignore colliders after spawning dye
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}