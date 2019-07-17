using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {
    public float radius = 3f;
    public Transform interactiontransform;
    bool isfocus = false;
    Transform player;
    bool hasinteract = false;

    public virtual void Movetointeract()
    {
       Debug.Log("Interact " + transform.name);
    }

    void Update()
    {
      if (isfocus && !hasinteract)
        {
            float distance = Vector3.Distance(player.position, interactiontransform.position);
            if (distance <= radius)
            {
                Movetointeract();
                hasinteract = true;
            }
        }    
    }

    public void Onfocus(Transform playertransform)
    {
        isfocus = true;
        player = playertransform;
        hasinteract = false;
    }

    public void Offfocus()
    {
        isfocus = false;
        player = null;
        hasinteract = false; 
    }

    private void OnDrawGizmosSelected()
    {
        if (interactiontransform == null)
            interactiontransform = transform;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactiontransform.position, radius);
    }
}
