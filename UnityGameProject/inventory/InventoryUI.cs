using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform slotparent;
    public GameObject inventoryUI;

    InventorySlot[] slot;

    inventory Inventory;
    // Use this for initialization
    void Start()
    {
        Inventory = inventory.instance;
        Inventory.itemchangedcallback += UpdateUI;

        slot = slotparent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")){
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        Debug.Log("updateui");

        for (int i = 0; i < slot.Length; i++)
        {
            if (i < Inventory.items.Count)
            {
                slot[i].AddItem(Inventory.items[i]);
            }
            else
            {
                slot[i].ClearSlot();
            }
        }
    }
}
