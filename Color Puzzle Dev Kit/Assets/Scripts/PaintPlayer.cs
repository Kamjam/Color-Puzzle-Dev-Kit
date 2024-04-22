using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPlayer : MonoBehaviour
{
    public SpriteRenderer Player;
    public Sprite playerDefault;

    //public GameObject currentDyeSlot;
    InventorySlot inventory;

    //For the player sprite swap
    //Ref. to the sprite that needs to change colors
    [SerializeField] Color printColor;
    [SerializeField] Sprite[] playerSprites;

    //color scriptable object
    GameColorPalette colors_db;

    void Start()
    {
        //find the player's inventory slot
        foreach (GameObject obj in FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.transform.IsChildOf(transform) && obj.CompareTag("Current Dye Slot"))
                inventory = obj.transform.GetComponent<InventorySlot>(); 
        }

        //currentDyeSlot = GetComponent<InventorySlot>(); 
    }

    void Update()
    {
        //check the selected dye and swap player sprite
        CheckAndSwap();
    }

    //changing the player's colors
    public void CheckAndSwap()
    {
        //count should correspond with the index of the palette database: 
        //red color, matches red player sprite
        int count = 0;
        if(inventory.playerColorTag == "Red")
        {
            printColor = colors_db.SetColor("Red");
            SwapSprite(count, printColor);
        }
        /*else if()
        {
            count = 1;
            SwapSprite(printColor);
        }
        else if()
        {
            SwapSprite(printColor);
        }
        else if()
        {
            SwapSprite(printColor);
        }
        else if()
        {
            SwapSprite(printColor);
        }
        else if()
        {
            SwapSprite(printColor);
        }*/

        //make sure that sprite has a default state
        else
        {
            Player.sprite = playerDefault;
        }
    }

    //Function to change the sprite
    public void SwapSprite(int index, Color color)
    {
        //index should correspond with the index of the palette database: red color, matches red player sprite
        Player.sprite = playerSprites[index];
        
        Debug.Log("The player is now a different color!" + "\n" + "Color: " + color);
    }
}