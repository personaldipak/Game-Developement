using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteract : Interact {
    public string[] dialouge;

    public override void Movetointeract()
    {
        DialougSystem.Instance.Adddialouge(dialouge, "Sign");
        base.Movetointeract();
    }
}
