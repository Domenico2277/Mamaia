using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    public int space = 9;
    public static Inventory instance;

     void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
        if (items.Count >= space)
            {
                Debug.Log("No more space for item");
                return false;
            }

        items.Add(item);

            if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();

        }
        return true;
        

    
    }
    
    public void Remove (Item item)
    {
        items.Remove(item);


        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();

    }



}
