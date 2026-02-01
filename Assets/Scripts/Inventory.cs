using UnityEngine;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[2];

    public void useKey()
    {
        for(int i = 0; i < 2; i++)
        {
            if (inventory[i] != null && inventory[i].CompareTag("Key"))
            {
                inventory[i] = null;
                Debug.Log("The key has been used");
                break;
            }
        }

    }

    public void addItem(GameObject item)
    {
        for(int i = 0; i < 2; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + " has been added to your inventory");
                break;
            }
            Debug.Log("Your Inventory is Full");
        }
    }
    public bool HasKey()
    {
        foreach (GameObject item in inventory)
        {
            if(item != null && item.CompareTag("Key"))
            {
                return true;
            }
        }
        return false;
    }

    public bool isFull()
    {
        return inventory[0] != null && inventory[1] != null;
    }
}
