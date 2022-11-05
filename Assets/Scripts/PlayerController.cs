using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotar))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    PlayerMotar motar;
    public LayerMask movementMask;
    public Interacable focus;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motar = GetComponent<PlayerMotar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motar.MoveToPoint(hit.point);
                RemoveFocus();
            }


        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                
                Interacable Interacable = hit.collider.GetComponent<Interacable>();
                if (Interacable != null)
                {
                    SetFocus(Interacable);
                }
            }

        }
    }
    void SetFocus(Interacable newFocus)
    {
        


        newFocus.OnFocused(transform);
            focus = newFocus;
        motar.FollowTarget(newFocus);
       
        
        
    }
    void RemoveFocus()
    {

        focus.OnDefocused();
        focus = null;
        motar.StopFollowingTarget();
    }







}
