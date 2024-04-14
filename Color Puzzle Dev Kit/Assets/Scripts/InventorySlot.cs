using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler    
{
    //dye data
    public string dyeColor;
    public int dyeAmount;
    public Sprite dyeSprite;
    public bool isFull; 

    [SerializeField] private int maxNumOfItems;

    //dye slot
    [SerializeField] private TMP_Text slotAmount;
    [SerializeField] private Image slotImage;

    public GameObject selectedPanel;
    public bool isSelected;
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string name, int amount, Sprite sprite)
    {
        //check to see if the slot is full
        if(isFull)
            return amount;

        //update name and sprite
        this.dyeColor = name;
        this.dyeSprite = sprite;
        slotImage.sprite = sprite;

        //update amount 
        this.dyeAmount += amount;
        //when the amount is over the max
        if(this.dyeAmount >= maxNumOfItems)
        {
            slotAmount.text = maxNumOfItems.ToString();
            slotAmount.enabled = true;
            isFull = true;

            //return leftovers
            int extraItems = this.dyeAmount - maxNumOfItems;
            this.dyeAmount = maxNumOfItems;
            return extraItems;
        }

        //update text without the amount calculations
        slotAmount.text = this.dyeAmount.ToString();
        slotAmount.enabled = true;

        //when there are no leftovers
        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if(eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();

        selectedPanel.SetActive(true);
        isSelected = true;
    }
    public void OnRightClick()
    {}
}