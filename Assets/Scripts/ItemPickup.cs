
using UnityEngine;

public class ItemPickup : Interacable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();


        Pickup();
    }



    void Pickup()
    {
       Debug.Log("Pickingup item" + item.name);
      bool wasPickedUp = Inventory.instance.Add(item);
     
     if (wasPickedUp)
        Destroy(gameObject);

    }









}
