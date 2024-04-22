using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler    
{
    //dye data
    [Tooltip("The dye color inside this inventory slot, will change once the player picks up an item, DO NOT EDIT")]
    [SerializeField] public string slot_dyeColor;

    [Tooltip("The dye amount inside this inventory slot, will change once the player picks up an item, DO NOT EDIT")]
    [SerializeField] public int slot_dyeAmount;

    [Tooltip("The dye sprite inside this inventory slot, will change once the player picks up an item, DO NOT EDIT")]
    [SerializeField] public Sprite slot_dyeSprite;

    [Tooltip("Checks whether or not this slot is full")]
    [SerializeField] public bool isFull; 

    [Tooltip("The dye color tag that is passed to the 'Player Paint' script, DO NOT EDIT")]
    [SerializeField] public string playerColorTag;

    [Tooltip("Sets the maximum amount of items allowed in this slot")]
    [SerializeField] private int maxNumOfItems;

    //dye slot
    [Tooltip("The 'Quantity Text' text object that will display the number of items in this slot")]
    [SerializeField] private TMP_Text slotAmount;

    [Tooltip("The 'Dye' image object that will display the image of the items in this slot")]
    [SerializeField] private Image slotImage;

    [Tooltip("The inventory panel that the inventory is displayed on")]
    public GameObject selectedPanel;

    [Tooltip("Checks whether or not a current item is selected, DO NOT EDIT")]
    public bool isSelected;

    //Ref. to inventory manager
    private InventoryManager inventoryManager;
    
    //Ref. to player's mini inventory
    private CurrentSlot currentSlot;
    
    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();

        currentSlot = GameObject.Find("Current Dye").GetComponent<CurrentSlot>();
    }

    public int AddItem(string name, int amount, Sprite sprite)
    {
        slotImage.enabled = true;

        //check to see if the slot is full
        if(isFull)
            return amount;

        //update name and sprite
        this.slot_dyeColor = name;
        this.slot_dyeSprite = sprite;
        slotImage.sprite = sprite;

        //update amount 
        this.slot_dyeAmount += amount;
        //when the amount is over the max
        if(this.slot_dyeAmount >= maxNumOfItems)
        {
            slotAmount.text = maxNumOfItems.ToString();
            slotAmount.enabled = true;
            isFull = true;

            //return leftovers
            int extraItems = this.slot_dyeAmount - maxNumOfItems;
            this.slot_dyeAmount = maxNumOfItems;
            return extraItems;
        }

        //update text without the amount calculations
        slotAmount.text = this.slot_dyeAmount.ToString();
        slotAmount.enabled = true;

        //when there are no leftovers
        return 0;
    }

    //Key press event
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        if(isSelected)
        {
            //push info to the mini slot
            currentSlot.AddToCurrentSlot(slot_dyeColor, slot_dyeSprite);

            this.slot_dyeAmount -= 1;
            slotAmount.text = this.slot_dyeAmount.ToString();

            //when the slot becomes 0
            if(this.slot_dyeAmount <= 0)
            {
                this.slot_dyeAmount = 0;
                EmptySlot();
            }
        }
        else
        {
            //deselects previous slot and switches
            inventoryManager.DeselectAllSlots();
            selectedPanel.SetActive(true);
            isSelected = true;
        }
    }

    public void EmptySlot()
    {
        slotAmount.enabled = false;

        slotImage.enabled = false;
        slotImage.sprite = null;
    }
}