using JetBrains.Rider.Unity.Editor;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player;
    [SerializeField] Canvas deathCanvas;

    [Header("Spawn")]
    [SerializeField] GameObject startingSpawn;
    [SerializeField, Tooltip("Offset of the player on the y axis so they don't spawn right in the center of the spawn point.")] 
    float spawnOffsetY;

    // Corpses
    [Header("Corpse Persistence")]
    [SerializeField] GameObject corpseObject;
    [SerializeField] int maxNumberOfCorpses = 5;
    List<GameObject> playerCorpses = new List<GameObject>();

    public PlayerSounds playerSounds;

    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    public void UnpauseGame()
    {
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        deathCanvas.gameObject.SetActive(false);
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    public void ResetPlayer()
    {
        playerSounds.PlayDeathSound();
        SpawnCorpse();
        StartCoroutine(MovePlayerToSpawn());
    }

    IEnumerator MovePlayerToSpawn()
    {
        Inventory playerInventory = player.GetComponentInChildren<Inventory>();
        CharacterController playerController = player.GetComponent<CharacterController>();
        playerController.enabled = false;

        Transform deathPosition = player.transform;
        playerInventory.dropleftitem(-0.5f, deathPosition);
        playerInventory.droprightitem(0.5f, deathPosition);

        Vector3 spawnPosition = startingSpawn.transform.position;
        spawnPosition.y += spawnOffsetY;
        player.transform.position = spawnPosition;
        player.transform.rotation = Quaternion.identity;



        Rigidbody playerBody = player.GetComponentInChildren<Rigidbody>();
        playerBody.position = new Vector3(0,0,0);

        yield return new WaitForEndOfFrame();

        
        playerController.enabled = true;

        playerSounds.StartPlayerSounds();
    }

    void SpawnCorpse()
    {
        GameObject newCorpse = Instantiate(corpseObject, player.transform.position, Quaternion.identity);
        if (playerCorpses.Count >= maxNumberOfCorpses)
        {
            GameObject playerCorpse = playerCorpses[0];
            playerCorpses.RemoveAt(0);
            Destroy(playerCorpse);
        }
        playerCorpses.Add(newCorpse);
    }
}
