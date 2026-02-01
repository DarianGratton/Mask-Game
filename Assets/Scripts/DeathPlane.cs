using StarterAssets;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [SerializeField, Tooltip("Needed for Kill Player function, should move to GameManager but not relevant for Jam.")]
    Oxygen killScript;

    [SerializeField]
    Inventory inventoryDropScript;

    [SerializeField]
    FirstPersonController playerController;

    private GameObject inventorySpawnLocation;

    private void Start()
    {
        inventorySpawnLocation = transform.Find("InventoryDropLocation").gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            killScript.KillPlayer();

            if (inventorySpawnLocation != null)
            {
                inventoryDropScript.dropleftitem(0.0f, inventorySpawnLocation.transform);
                inventoryDropScript.droprightitem(0.0f, inventorySpawnLocation.transform);
            }

            // Set player velocity to zero
            playerController.ResetVelocity();
        }
    }
}
