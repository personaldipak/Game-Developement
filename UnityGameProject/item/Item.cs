using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "new item";
    public Sprite icon = null;
    public bool defaultitem = false;

    public virtual void Use()
    {
        Debug.Log("Using" + name);
        if (name == "Potion")
        {
            Debug.Log("increase health by 25");
            GameObject.Find("player").GetComponent<PlayerStats>().HealDamage(25);
            RemoveInventory();
        }
    }

    public void RemoveInventory()
    {
        inventory.instance.Remove(this);
    }
}
