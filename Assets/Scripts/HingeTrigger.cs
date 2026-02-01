using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;

    public void OnTriggerEnter(Collider other)
    {
        // Try to find the Inventory on the object that entered the trigger
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory != null)
        {
            if (inventory.HasKey())
            {
                if (door != null)
                {
                    door.SetActive(false);
                    inventory.useKey();
                    Debug.Log("Door Opened!");

                }
            }
            else
            {
                Debug.Log("You do not have the means to open this door");
            }
        }
    }
}