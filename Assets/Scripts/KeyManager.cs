using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public bool hasKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collisionInfo)
    {
        // Check the tag or name of the object the player collided with
        if (collisionInfo.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            
        }

        if (collisionInfo.gameObject.CompareTag("Hinge"))
        {
            hasKey = false;
            
        }

    }
}
