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
        InventoryMenu.SetActive(false);
        toggleMenu = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i") && !toggleMenu)
        {
            InventoryMenu.SetActive(true);
            toggleMenu = true;
            
            Debug.Log("Menu Opened");

            //pause
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown("i") && toggleMenu)
        {
            //unpause
            Time.timeScale = 1;

            InventoryMenu.SetActive(false);
            toggleMenu = false;

            Debug.Log("Menu Closed");
        }
    }
}
