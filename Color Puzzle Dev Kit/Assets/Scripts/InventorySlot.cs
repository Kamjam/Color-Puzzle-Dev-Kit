using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData edata)
    {
        //prevent the overlap
        if(transform.childCount == 0)
        {
            GameObject dropped = edata.pointerDrag;

            DraggableItem dItem = dropped.GetComponent<DraggableItem>();
            dItem.parentAfterDrag = transform;
        }
    }
}