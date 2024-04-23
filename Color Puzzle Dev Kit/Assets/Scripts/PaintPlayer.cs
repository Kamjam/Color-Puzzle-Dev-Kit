using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPlayer : MonoBehaviour
{
    [Tooltip("The player's sprite renderer")]
    public SpriteRenderer Player;

    [Tooltip("The player object")]
    public GameObject playerObject;

    [Tooltip("The player's default sprite")]
    public Sprite playerDefault;

    //Ref. to the current slot script
    [Tooltip("The player's mini inventory slot")]
    CurrentSlot currentSlot;

    //Ref. to the player sprite that while change
    [Tooltip("Array for all the player's sprite in the same order as the colors inside the scriptable object color palette array")]
    [SerializeField] Sprite[] playerSprites;

    [Tooltip("The player's color picker color, DO NOT EDIT")]
    [SerializeField] Color printColor;

    //Ref. to the Color scriptable object
    [Tooltip("The Game Color Palette Scriptable Object, which stores all the colors for easy access")]
    public GameColorPalette colors_db;

    [Tooltip("Checks whether or not the player has changed colors, DO NOT EDIT")]
    public bool iscolorSwapped;

    void Start()
    {
        currentSlot = GameObject.Find("Current Dye").GetComponent<CurrentSlot>();
    }

    void Update()
    {
        //check the selected dye and swap player sprite
        CheckAndSwap();
    }

    //changing the player's colors
    public void CheckAndSwap()
    {
        //count should correspond with the index of the player sprite array: 
        //red color matches red player sprite, which both are index 0
        int count = 0;

        if(currentSlot.playerColorTag == "Red")
        {
            var color = colors_db.GetColor("Red");
            //swapSprite(count);
            swapSprite(count, color);
        }
        else if(currentSlot.playerColorTag == "Orange")
        {
            count = 1;
            var color = colors_db.GetColor("Orange");
            //swapSprite(count);
            swapSprite(count, color);
        }
        else if(currentSlot.playerColorTag == "Yellow")
        {
            count = 2;
            var color = colors_db.GetColor("Yellow");
            //swapSprite(count);
            swapSprite(count, color);
        }
        else if(currentSlot.playerColorTag == "Green")
        {
            count = 3;
            var color = colors_db.GetColor("Green");
            //swapSprite(count);
            swapSprite(count, color);
        }
        else if(currentSlot.playerColorTag == "Aqua")
        {
            count = 4;
            var color = colors_db.GetColor("Aqua");
            //swapSprite(count);
            swapSprite(count, color);
        }
        else if(currentSlot.playerColorTag == "Blue")
        {
            count = 5;
            var color = colors_db.GetColor("Blue");
            //swapSprite(count);
            swapSprite(count, color);
        }
        else if(currentSlot.playerColorTag == "Purple")
        {
            count = 6;
            var color = colors_db.GetColor("Purple");
            //swapSprite(count);
            swapSprite(count, color);
        }
        else if(currentSlot.playerColorTag == "Pink")
        {
            count = 7;
            var color = colors_db.GetColor("Pink");
            //swapSprite(count);
            swapSprite(count, color);
        }
        //make sure that sprite has a default state
        else
        {
            Player.sprite = playerDefault;
        }
    }

    //Function to change the sprite
    public void swapSprite(int index, Color color)
    {
        printColor = color;
        iscolorSwapped = true;

        //index should correspond with the index of the palette database: red color, matches red player sprite
        Player.sprite = playerSprites[index];

        if(iscolorSwapped)
            Debug.Log("The player is now a different color!" + "\n" + "Color: " + ColorUtility.ToHtmlStringRGB(printColor));
    }
}