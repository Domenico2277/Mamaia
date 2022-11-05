using UnityEngine;

public class Interacable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;
    public Transform interactionTransform;
    public virtual void Interact()
    {
       
    }
    void Update ()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
               
            }

        }
    }
    public void OnFocused(Transform playerTransform)
    {
        hasInteracted = false;
        isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        hasInteracted = false;
        isFocus = false;
        player = null;
    }
     void OnDrawGizmos()
    {
        if (interactionTransform == null)
            interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }








}
