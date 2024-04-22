using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dye : MonoBehaviour
{
    
    [Tooltip("The color of this dye")]
    [SerializeField] private string dyeColor;
    
    [Tooltip("The correct sprite for this dye color")]
    [SerializeField] private Sprite dyeSprite;
    
    [Tooltip("The amount this dye object gives when the player picks it up")]
    [SerializeField] private int dyeAmount;

    //Ref. to inventory manager
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        //find the inventory manager code inside the canvas
        inventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //collision with player adds the dye to the inventory
        if(collision.gameObject.tag == "Player")
        {
            //calculate and return an int
            int leftOverItems = inventoryManager.AddDye(dyeColor, dyeSprite, dyeAmount);

            if(leftOverItems <= 0)
                Destroy(gameObject);
            else
                dyeAmount = leftOverItems;
        }
    }
}