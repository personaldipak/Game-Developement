using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    inventory inventory;

    public delegate void onEquipmentChanged(Equipment newItem, Equipment olditem);
    public onEquipmentChanged equipmentchanged;


    void Start()
    {
        inventory = inventory.instance;
        int numslot = System.Enum.GetNames(typeof(Equipmentslot)).Length;
        currentEquipment = new Equipment[numslot];
    }

    public void Equip (Equipment newItem)
    {
        int slotindex = (int)newItem.equip;
        Equipment olditem = null;
        
        if (currentEquipment[slotindex] != null)
        {
            olditem = currentEquipment[slotindex];
            inventory.Add(olditem);
        }

        if (equipmentchanged != null)
        {
            equipmentchanged.Invoke(newItem, olditem);
        }
        currentEquipment[slotindex] = newItem;
    }

    public void UnEquip( int slotindex)
    {
        if (currentEquipment[slotindex] != null)
        {
            Equipment olditem = currentEquipment[slotindex];
            inventory.Add(olditem);

            currentEquipment[slotindex] = null;

            if (equipmentchanged != null)
            {
                equipmentchanged.Invoke(null, olditem);
            }
        }
    }

    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnEquipAll();
        }    
    }
}
