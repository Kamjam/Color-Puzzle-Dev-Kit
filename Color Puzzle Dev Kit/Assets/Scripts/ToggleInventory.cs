using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    public GameObject InventoryMenu;
    public bool toggleMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        InventoryMenu.SetActive(false);
        toggleMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && !toggleMenu)
        {
            InventoryMenu.SetActive(true);
            toggleMenu = true;
            
            Debug.Log("Menu Opened");

            //pause
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown("space") && toggleMenu)
        {
            //unpause
            Time.timeScale = 1;

            InventoryMenu.SetActive(false);
            toggleMenu = false;

            Debug.Log("Menu Closed");
        }
    }
}
