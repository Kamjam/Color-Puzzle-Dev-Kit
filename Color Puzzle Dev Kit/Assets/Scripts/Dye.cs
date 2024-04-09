using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dye : MonoBehaviour
{
    [SerializeField] private string dyeColor;
    [SerializeField] private Sprite sprite;

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
            inventoryManager.AddDye(dyeColor, sprite);
            Destroy(gameObject);
        }
    }
}
