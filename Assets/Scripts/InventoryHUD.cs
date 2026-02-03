using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    public Image leftHandSlot;
    public Image rightHandSlot;

    public Inventory inventory;

    public bool leftSpriteOn = false;
    public bool rightSpriteOn = false;


    public Sprite emptySlotSprite;

    void Start()
    {
        leftHandSlot.sprite = emptySlotSprite;
        rightHandSlot.sprite = emptySlotSprite;
    }
    void Update()
    {   
        UpdateHandSlots();
    }

    void UpdateHandSlots()
    {

    
    
        if(inventory.inventory[0] != null)
        {
            if (!leftSpriteOn)
            {
                Debug.Log("Left hand item picked up!!!!!");
                leftHandSlot.sprite = inventory.inventory[0].GetComponent<HudSprite>().getHudSprite();
                leftSpriteOn = true;
            }

        }
        else
        {
            if (leftSpriteOn)
            {
                leftHandSlot.sprite = emptySlotSprite;
                leftSpriteOn = false;
            }
            
        }


        if(inventory.inventory[1] != null)
        {
            if (!rightSpriteOn)
            {
                Debug.Log("Left hand item picked up!!!!!");
                rightHandSlot.sprite = inventory.inventory[1].GetComponent<HudSprite>().getHudSprite();
                rightSpriteOn = true;
            }

        }
        else
        {
            if (rightSpriteOn)
            {
                rightHandSlot.sprite = emptySlotSprite;
                rightSpriteOn = false;
            }
            
        }

    }
}
