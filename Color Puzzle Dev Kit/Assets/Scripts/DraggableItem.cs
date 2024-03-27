using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData edata)
    {
        Debug.Log("Begin Drag");
        parentAfterDrag = transform.parent;

        //sets the parent at whichever slot the color is attached to
        transform.SetParent(transform.root);
        //place at the top of the hierarchy
        transform.SetAsLastSibling();

        //disable the raycasting while dragging so that the object can be placed into the correct slot
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData edata)
    {
        Debug.Log("Dragging");

        //while you drag this item it will follow the mouse
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData edata)
    {
        Debug.Log("End Drag");

        //prevent this object from being under the other things
        transform.SetParent(parentAfterDrag);

        //reenable raycasting
        image.raycastTarget = true;
    }
}
