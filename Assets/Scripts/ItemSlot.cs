using Inventario;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
  public GameObject Item
  {
    get
    {
      if (transform.childCount > 1)
      {
        return transform.GetChild(0).gameObject;
      }

      return null;
    }
  }

  public void OnDrop(PointerEventData eventData)
  {
    Debug.Log($"OnDrop {eventData}");

    Inventory.MoveItemToSlot(Item.tag);

    if (Item.tag.Equals("Image07"))
    {
      Debug.Log("Arrastre item al slot 07");
    }

    //if there is not item already then set our item.
    if (!Item)
    {

      DragDrop.itemBeingDragged.transform.SetParent(transform);
      DragDrop.itemBeingDragged.transform.localPosition = new Vector2(0, 0);

    }


  }
}
