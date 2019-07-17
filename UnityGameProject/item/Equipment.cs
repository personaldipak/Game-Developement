using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "inventory/Equipment")]
public class Equipment : Item {

    public Equipmentslot equip;
    public int armour;
    public int damage;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveInventory();
    }
}

public enum Equipmentslot { sword, shield }