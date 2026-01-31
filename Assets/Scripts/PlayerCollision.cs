using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject DoorManager;
    // This function is called when this collider/rigidbody has begun touching another rigidbody/collider
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("A collision has occured between" + collisionInfo.gameObject + "and player");
        // Check the tag or name of the object the player collided with
        if (collisionInfo.gameObject.CompareTag("Key"))
        {
            Debug.Log("The Door Shall Open");
         //   DoorManager.openDoorWithHinge(collisionInfo.gameObject);
        }


    }
}