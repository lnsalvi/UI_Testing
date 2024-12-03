using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using UnityEngine;

namespace Inventario
{
  internal static class Inventory
  {
    private static readonly List<Item> Slots = new List<Item>();
    private static readonly int NumberOfSlots = 20;
    private static readonly int NumberOfItemsPerSlot = 50;
    private static bool WereThereAnyItemsAdded;

    public static Item[] GetInventory()
    {
      Item[] inventoryTemp = new Item[NumberOfSlots];

      for (int i = 0; i < 20; i++)
      {
        if (i < Slots.Count) inventoryTemp[i] = Slots[i];
        else inventoryTemp[i] = new Item("Empty", 0);
      }

      return inventoryTemp;
    }

    private static bool AreThereAnyEmptySlot() => Slots.Count < NumberOfSlots;

    public static void ShowInventoryConsole()
    {
      foreach (Item item in Slots)
      {
        UnityEngine.Debug.Log($"{item.ItemName}");
      }
    }
    public static void AddItemToForce()
    {
      Slots.Add(new Item("Wood01", 15));  // 01
      Slots.Add(new Item("Wood01", 2));   // 02
      Slots.Add(new Item("Wood01", 4));   // 03
      Slots.Add(new Item("Wood01", 28));  // 04
      Slots.Add(new Item("Wood01", 33));  // 05
      Slots.Add(new Item("Wood01", 44));  // 06
      //Slots.Add(new Item("Empty", 0));    // 07
      //Slots.Add(new Item("Empty", 0));    // 08
      //Slots.Add(new Item("Empty", 0));    // 09
      //Slots.Add(new Item("Empty", 0));    // 10
      //Slots.Add(new Item("Empty", 0));    // 11
      //Slots.Add(new Item("Empty", 0));    // 12
      //Slots.Add(new Item("Empty", 0));    // 13
      //Slots.Add(new Item("Empty", 0));    // 13
      //Slots.Add(new Item("Empty", 0));    // 15
      //Slots.Add(new Item("Empty", 0));    // 16
      //Slots.Add(new Item("Empty", 0));    // 17
      //Slots.Add(new Item("Empty", 0));    // 18
      //Slots.Add(new Item("Empty", 0));    // 19
      //Slots.Add(new Item("Empty", 0));    // 20
    }

    public static string AddItem(Item itemToStore)
    {
      if (StoreItem(itemToStore, false)) return "Items agregados al inventario";
      return "Inventario lleno";
    }

    private static bool StoreItem(Item itemToStore, bool HaveBeenAdded)
    {
      List<Item> itemsFounds = new List<Item>();
      if (!HaveBeenAdded) itemsFounds = Slots.FindAll(x => x.ItemName == itemToStore.ItemName);

      if (itemsFounds.Count > 0 && itemToStore.Quantity > 0 && !HaveBeenAdded)  // Add quantities to existing items.
      {
        WereThereAnyItemsAdded = true;
        itemToStore.Quantity = AddQuantitiesInItems(itemsFounds, itemToStore.Quantity);
      }

      if (AreThereAnyEmptySlot() && itemToStore.Quantity > 0)  // Add new slot, with the item and the missing quantity or the maximum.
      {
        WereThereAnyItemsAdded = true;
        int quantityToStore = itemToStore.Quantity > NumberOfItemsPerSlot ? NumberOfItemsPerSlot : itemToStore.Quantity;
        Item itemSave = new Item(itemToStore.ItemName, quantityToStore);
        Slots.Add(itemSave);

        if (itemToStore.Quantity > NumberOfItemsPerSlot) itemToStore.Quantity -= NumberOfItemsPerSlot;
        else itemToStore.Quantity = 0;

        if(itemToStore.Quantity > 0) StoreItem(itemToStore, true);
      }

      return WereThereAnyItemsAdded;
    }

    private static int AddQuantitiesInItems(List<Item> itemsFounds, int HowMuchQuantity)
    {
      foreach (Item itemFound in itemsFounds)
      {
        int HowMuchCanIAdd = NumberOfItemsPerSlot - itemFound.Quantity;

        if (HowMuchCanIAdd > HowMuchQuantity)
        {
          itemFound.Quantity += HowMuchQuantity;
          HowMuchQuantity = 0;
          break;
        }
        else itemFound.Quantity += HowMuchCanIAdd;
        HowMuchQuantity -= HowMuchCanIAdd;
      }

      return HowMuchQuantity;
    }
  }
}
