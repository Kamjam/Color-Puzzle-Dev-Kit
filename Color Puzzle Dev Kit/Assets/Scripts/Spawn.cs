using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Ref. to colorswap script
    private ColorSwap textbox;

    float moveSpeed = -0.02f;

    void Start()
    {
        textbox = ColorSwap.instance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (0, moveSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //destroy itself when it collides with a boundary, and show the fortune
        if(other.gameObject.tag == "Boundary")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            //show the text
            textbox.showWords();
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        //destroy itself when it collides with a boundary, and show the fortune
        if(other.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);

            //show the text
            textbox.hideWords();
        }
    }
}