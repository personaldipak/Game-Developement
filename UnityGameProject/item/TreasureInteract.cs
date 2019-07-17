using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureInteract : Interact {

    public GameObject Potions;
    public GameObject Coins;
    public GameObject Pileofcoins;
    public GameObject Diamond;
    public GameObject giftbag;

    public override void Movetointeract()
    {
        base.Movetointeract();
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        int items = Random.Range(0, 5);
        
        if (items == 0)
        {
           Instantiate(Potions, transform.position, transform.rotation);
        }
        if (items == 1)
        {
            Instantiate(Coins, transform.position, transform.rotation);
        }
        if (items == 2)
        {
            Instantiate(Pileofcoins, transform.position, transform.rotation);
        }
        if (items == 3)
        {
            Diamond.SetActive(true);
            Instantiate(Diamond, transform.position, transform.rotation);
        }
        if (items == 4)
        {
            giftbag.SetActive(true);
            Instantiate(giftbag, transform.position, transform.rotation);
        }
    }
}
