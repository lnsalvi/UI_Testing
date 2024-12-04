using Inventario;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
  public GameObject InventoryMenu;
  public GameObject InventorySlots;
  public bool MenuActivated;
  public List<GameObject> slotList = new List<GameObject>();

  private Sprite img1;
  private Image imageSlot;

  private void Awake() => Inventory.AddItemToForce();
  void Start()
  {
    MenuActivated = false;
    PopulateSlotList();
    UpdateInventoryUi();
  }

  void Update()
  {
    if (Input.GetButtonDown("Inventory") && MenuActivated)
    {
      InventoryMenu.SetActive(false);
      MenuActivated = false;
    }
    else if (Input.GetButtonDown("Inventory") && !MenuActivated)
    {
      UpdateInventoryUi();
      InventoryMenu.SetActive(true);
      MenuActivated = true;
    }

    if (Input.GetButtonDown("ShowInventory")) {
      Inventory.ShowInventoryConsole();
    }
  }

  public void AddItem( string name, int quantity, Sprite sprite )
  {
    Debug.Log($"{name} {quantity} {sprite}");
  }

  private void PopulateSlotList()
  {
    foreach (Transform child in InventorySlots.transform)
    {
      if (child.CompareTag("Slot")) slotList.Add(child.gameObject);
    }
  }

  private void UpdateInventoryUi()
  {
    Item[] inventory = Inventory.GetInventory();

    int cnt = 0;
    foreach (GameObject slot in slotList)
    {
      Image imageSlot = slot.transform.Find("Image")?.GetComponent<Image>();
      TextMeshProUGUI textMeshProUGUISlot = slot.transform.Find("Text")?.GetComponent<TextMeshProUGUI>();

      //Debug.Log(textMeshSlot);

      imageSlot.sprite = Resources.Load<Sprite>($"Sprites/{inventory[cnt].ItemName}");
      textMeshProUGUISlot.text = $"{inventory[cnt].Quantity}";

      cnt++;
    }
  }
}
