using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Use this for initialization
    void Start ()
    {
        EquipmentManager.instance.equipmentchanged += onEquipmentChanged;
    }

    void onEquipmentChanged(Equipment newItem, Equipment olditem)
    {
        if (newItem != null)
        {
            armour.AddModifier(newItem.armour);
            damage.AddModifier(newItem.damage);
        }

        if(olditem != null)
        {
            armour.RemoveModifier(olditem.armour);
            armour.RemoveModifier(olditem.damage);
        }
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.Killplayer();
    }
}
