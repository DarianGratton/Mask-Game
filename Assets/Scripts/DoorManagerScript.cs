using UnityEngine;
using System.Collections.Generic;

public class DoorManagerScript : MonoBehaviour
{

    [System.Serializable]
    public class KeyValuePair<TKey, TValue>
    {
        public TKey key;
        public TValue value;
    }
public List<KeyValuePair<GameObject, GameObject>> MyList = new List<KeyValuePair<GameObject, GameObject>>();
    [SerializeField] public Dictionary<GameObject, GameObject> doors = new Dictionary<GameObject, GameObject>();

    // Call this method to open a specific door via its hinge
    public void OpenDoorWithHinge(GameObject hinge)
    {
        if (doors.ContainsKey(hinge))
        {
            GameObject door = doors[hinge];
            // Rotate the door 90 degrees on the Y axis locally
            door.transform.Rotate(0, 90, 0); 
            Debug.Log(door.name + " opened.");
        }
    }
}