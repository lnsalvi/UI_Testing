using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  [SerializeField]
  private string ItemName;
  [SerializeField]
  private int Quantity;
  [SerializeField]
  private Sprite SpriteItem;

  private InventoryManager inventoryManager;
  
  void Start()
  {
    inventoryManager = GameObject.Find("UI_Canvas").GetComponent<InventoryManager>();
  }

  private void OnCollisionEnter( Collision collision )
  {
    if ( collision.gameObject.tag.Equals("Player"))
    {
      //inventoryManager.AddItem(ItemName, Quantity, SpriteItem);
      Debug.Log($"{ItemName}, {Quantity}");
      Destroy(gameObject);
    }
  }
}
