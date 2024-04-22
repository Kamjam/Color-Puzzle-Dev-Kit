using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    [Tooltip("An array of all inventory slots, Drag all/any new slots inside this dropdown")]
    public InventorySlot[] inventorySlot;
    
    public int AddDye(string color, Sprite sprite, int amount)
    {
        Debug.Log("Dye_Color: " + color + "\n" + "Amount: " + amount + "\n"  +  "Dye_Sprite: " + sprite);

        for(int i = 0; i < inventorySlot.Length; i++)
        {
            //not full and the names match or there is no quantity
            if(inventorySlot[i].isFull == false && inventorySlot[i].slot_dyeColor == color || inventorySlot[i].slot_dyeAmount == 0)
            {
                int leftOverItems = inventorySlot[i].AddItem(color, amount, sprite);
                //check the number of leftovers
                if(leftOverItems > 0)
                    leftOverItems = AddDye(color, sprite, leftOverItems);

                return leftOverItems;
            }
        }
        
        return amount;
    }

    public void DeselectAllSlots()
    {
        for(int i = 0; i < inventorySlot.Length; i++)
        {
            inventorySlot[i].selectedPanel.SetActive(false); 
            inventorySlot[i].isSelected = false; 
        }
    }
}