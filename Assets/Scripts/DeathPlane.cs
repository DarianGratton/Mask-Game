using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [Tooltip("Needed for Kill Player function, should move to GameManager but not relevant for Jam.")]
    public Oxygen killScript; 

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            killScript.KillPlayer();
        }
    }
}
