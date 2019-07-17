using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    public Button RemoveButton;

    Item Item;

    public void AddItem(Item newItem)
    {
        Item = newItem;

        icon.sprite = Item.icon;
        icon.enabled = true;
        RemoveButton.interactable = true;
    }

    public void ClearSlot()
    {
        Item = null;
        icon.sprite = null;
        icon.enabled = false;
        RemoveButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        inventory.instance.Remove(Item);
        Debug.Log("remove  item");
    }

    public void Useitem()
    {
        if(Item != null)
        {
            Item.Use();
        }
    }
}
