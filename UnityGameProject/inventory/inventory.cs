using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour {

    #region singleton
    public static inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More inventory found");
            return;
        }
        instance = this;
    }

    #endregion 

    public delegate void Itemchanged();
    public Itemchanged itemchangedcallback;


    public int space = 8;

    public List<Item> items = new List<Item>();
    public GameObject Items;

    public bool Add (Item item)
    {
        if (!item.defaultitem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Ran out of Space");
                return false;
            }
            items.Add(item);

            if(itemchangedcallback != null)
               itemchangedcallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (itemchangedcallback != null)
            itemchangedcallback.Invoke();
    }
}
