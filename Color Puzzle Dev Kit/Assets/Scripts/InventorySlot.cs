using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler    
{
    //dye data
    public string slot_dyeColor;
    public int slot_dyeAmount;
    public Sprite slot_dyeSprite;
    public bool isFull; 

    public string playerColorTag;

    [SerializeField] private int maxNumOfItems;

    //dye slot
    [SerializeField] private TMP_Text slotAmount;
    [SerializeField] private Image slotImage;

    //the dye slot that shows up and moves with the player
    [SerializeField] public Image currentSlotImage;

    public GameObject selectedPanel;
    public bool isSelected;

    //Ref. to inventory manager
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string name, int amount, Sprite sprite)
    {
        slotImage.enabled = true;

        //check to see if the slot is full
        if(isFull)
            return amount;

        //update name and sprite
        this.slot_dyeColor = name;
        tagPlayer(this.slot_dyeColor);

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

    //Tagging the player to pass the color to the paintPlayer function
    public void tagPlayer(string colorTag)
    {
        playerColorTag = colorTag;
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
            //change the mini player slot
            currentSlotImage.sprite = slot_dyeSprite;

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