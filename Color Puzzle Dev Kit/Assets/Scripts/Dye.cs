using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dye : MonoBehaviour
{
    [SerializeField] private string dyeColor;
    [SerializeField] private Sprite dyeSprite;
    [SerializeField] private int dyeAmount;

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
