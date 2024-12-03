using Inventario;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
  public string ItemName;
  public int Quantity;
  private GameObject ObjInventoryManager;

  void Start()
  {
    ObjInventoryManager = GameObject.Find("InventoryManager");
  }

  private void OnCollisionEnter( Collision collision )
  {
    if (collision.gameObject.tag.Equals("Player"))
    {
      Debug.Log($"{ItemName}, {Quantity}");

      Item item = new Item(this.ItemName, this.Quantity);
      Inventory.AddItem(item);

      Destroy(gameObject);
    }

    ObjInventoryManager.SendMessage("UpdateInventoryUi");
  }
}
