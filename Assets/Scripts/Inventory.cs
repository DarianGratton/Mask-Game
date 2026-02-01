using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[2];





    public void dropleftitem(float offset, Transform playerTransform = null)
    {
        playerTransform = transform;
        GameObject item = inventory[0];
        if(item != null)
        {
            item.SetActive(true);
            Vector3 dropPosition = playerTransform.position + (playerTransform.forward * offset);
        
            item.transform.position = dropPosition;
            
            inventory[0] = null;
            Debug.Log("You have dropped " + item.name);
        }
    
    }

    public void droprightitem(float offset, Transform playerTransform = null)
    {
        playerTransform = transform;
        GameObject item = inventory[1];

        if(item != null)
        {
            item.SetActive(true);
            Vector3 dropPosition = playerTransform.position + (playerTransform.forward * offset);
        
            item.transform.position = dropPosition;
            
            inventory[1] = null;
            Debug.Log("You have dropped " + item.name);
        }
    }
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

    public GameObject useKeyCard()
    {
        for(int i = 0; i < 2; i++)
        {
            Debug.Log("inventory[i] is equal to this value: " + inventory[i]);
            if (inventory[i] != null && inventory[i].CompareTag("KeyCard"))
            {
                GameObject keyCardUsed = inventory[i];

                Debug.Log("keyCardUSed is equal to this value: " + keyCardUsed);

            
                inventory[i] = null;
                Debug.Log("The key card has been used");
                return keyCardUsed;


            }
        }
        return null;
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

    public bool hasKeyCard()
    {
        foreach (GameObject item in inventory)
        {
            if(item != null && item.CompareTag("KeyCard"))
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
