using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class CurrentSlot : MonoBehaviour    
{
    //slot data
    [Tooltip("The dye color inside this inventory slot, will change once the player picks up an item, DO NOT EDIT")]
    public string slot_dyeColor;

    [Tooltip("The dye sprite inside this inventory slot, will change once the player picks up an item, DO NOT EDIT")]
    public Sprite slot_dyeSprite;

    [Tooltip("The dye color tag that is passed to the 'Player Paint' script, DO NOT EDIT")]
    public string playerColorTag;

    //the dye slot that shows up and moves with the player
    [Tooltip("The current image of the item inside this slot, DO NOT EDIT")]
    [SerializeField] public Image currentSlotImage;

    public void AddToCurrentSlot(string name, Sprite sprite)
    {
        currentSlotImage.enabled = true;

        //update name and sprite
        this.slot_dyeColor = name;
        tagPlayer(this.slot_dyeColor);

        this.slot_dyeSprite = sprite;
        currentSlotImage.sprite = sprite;
    }

    //Tagging the player to pass the color to the paintPlayer function
    public void tagPlayer(string colorTag)
    {
        playerColorTag = colorTag;
    }
}