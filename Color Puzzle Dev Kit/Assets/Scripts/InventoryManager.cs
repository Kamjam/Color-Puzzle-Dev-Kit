using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public void AddDye(string color, Sprite sprite)
    {
        Debug.Log("Dye_Color: " + color + "\n" + "Dye_Sprite: " + sprite);
    }
}
