using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMove))]
public class playercontroller : MonoBehaviour {

    public Interact focus;
    public LayerMask movemask;
    Camera cam;
    PlayerMove move;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        move = GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {

        if (EventSystem.current.IsPointerOverGameObject())
        return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movemask))
            {
                Debug.Log("we hit " + hit.collider.name + " " + hit.point);
                move.move(hit.point);
                //move our player to what we hit

                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interact interactable = hit.collider.GetComponent<Interact>();
                if (interactable != null)
                {
                    Setfocus(interactable);

                }
            }
        }
    }

    void Setfocus(Interact newFocus)
    {
        if (newFocus != focus)
        {
            if(focus != null)
             focus.Offfocus();

        focus = newFocus;
        move.followTarget(newFocus);
        }
        newFocus.Onfocus(transform);
        
    }

    void RemoveFocus()
    {
        if(focus != null)
          focus.Offfocus();

     focus = null;
     move.stopTarget();
    }
}
