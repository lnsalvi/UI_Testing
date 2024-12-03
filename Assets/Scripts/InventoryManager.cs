using System.Collections;
using System.Collections.Generic;
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
      InventoryMenu.SetActive(true);
      MenuActivated = true;
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
    Image imageSlot_1 = slotList[0].transform.Find("Image")?.GetComponent<Image>();
    Image imageSlot_2 = slotList[1].transform.Find("Image")?.GetComponent<Image>();

    Sprite img1 = Resources.Load<Sprite>("Sprites/spade");
    Sprite img2 = Resources.Load<Sprite>("Sprites/stone");

    imageSlot_1.sprite = img1;
    imageSlot_2.sprite = img2;
  }
}
