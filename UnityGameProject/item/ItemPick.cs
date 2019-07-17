using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : Interact {

    public Item item;

    public override void Movetointeract()
    {
        base.Movetointeract();
        Pickup();
    }

    void Pickup()
    {
        Debug.Log("pickup item: " + item.name);
        bool waspick = inventory.instance.Add(item);

        if (waspick)
           Destroy(gameObject);
    }
}
