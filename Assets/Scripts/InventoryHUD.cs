using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    public Image leftHandSlot;
    public Image rightHandSlot;

    public Inventory inventory;

    void Update()
    {
        UpdateHandSlots();
    }

    void UpdateHandSlots()
    {
        // Left hand (inventory[0])
        if (inventory.inventory[0] != null)
        {
            SpriteRenderer sr = inventory.inventory[0].GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                leftHandSlot.sprite = sr.sprite;
                leftHandSlot.enabled = true;
            }
        }
        else
        {
            leftHandSlot.enabled = false;
        }

        // Right hand (inventory[1])
        if (inventory.inventory[1] != null)
        {
            SpriteRenderer sr = inventory.inventory[1].GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                rightHandSlot.sprite = sr.sprite;
                rightHandSlot.enabled = true;
            }
        }
        else
        {
            rightHandSlot.enabled = false;
        }
    }
}
