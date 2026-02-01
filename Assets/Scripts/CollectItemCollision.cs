using UnityEngine;

public class CollectItemCollision : MonoBehaviour
{
    public PlayerSounds sound;

    void OnCollisionEnter(Collision collisionInfo)
    {
        Inventory inventory = collisionInfo.gameObject.GetComponent<Inventory>();
        if (inventory == null)
            return;

        if (!inventory.isFull())
        {
            inventory.addItem(this.gameObject);
            this.gameObject.SetActive(false);

            sound.PlayPickupSound();
        }
        else
        {
            Debug.Log("Your inventory is full!");
        }



    } 

}
