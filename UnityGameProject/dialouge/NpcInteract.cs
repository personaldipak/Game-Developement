using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteract : Interact {

    public string[] dialouge;
    public string nametext;
 
    public override void Movetointeract()
    {
        DialougSystem.Instance.Adddialouge(dialouge, nametext);
        base.Movetointeract();
    }
}
