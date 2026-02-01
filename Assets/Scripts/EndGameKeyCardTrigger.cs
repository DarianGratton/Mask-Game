using UnityEngine;

public class EndGameKeyCardTrigger : MonoBehaviour
{

    public void OnTriggerEnter(Collider collider)
    {
        Inventory playerInventory = collider.GetComponent<Inventory>();
        EndGameInventory reactorInventory = this.gameObject.GetComponent<EndGameInventory>();

        if (playerInventory != null)
        {
            if (playerInventory.hasKeyCard())
            {
                GameObject keyCardUsed = playerInventory.useKeyCard();
                Debug.Log("keyCardUsed is equal to: " + keyCardUsed);
                reactorInventory.addKeyCard(keyCardUsed);
                
                Debug.Log("Door Opened!");
            }
            else
            {
                Debug.Log("You do not have a key card!");
            }
        }
    }
}
