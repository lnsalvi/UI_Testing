using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
  public string ItemName { get; set; }
  public int Quantity { get; set; }
  
  public Item(string itemName, int quantity)
  {
    ItemName = itemName;
    Quantity = quantity;
  }
}
