using UnityEngine;

public class CollectItemCollision : MonoBehaviour
{
    public GameObject DoorManager;
    void OnCollisionEnter(Collision collisionInfo)
    {
        Inventory inventory = collisionInfo.gameObject.GetComponent<Inventory>();

        if (!inventory.isFull())
        {
            inventory.addItem(this.gameObject);
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Your inventory is full!");
        }



    } 

}
