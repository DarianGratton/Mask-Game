using JetBrains.Rider.Unity.Editor;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player;

    [Header("Spawn")]
    [SerializeField] GameObject startingSpawn;
    [SerializeField, Tooltip("Offset of the player on the y axis so they don't spawn right in the center of the spawn point.")] 
    float spawnOffsetY;

    // Corpses
    [Header("Corpse Persistence")]
    [SerializeField] GameObject corpseObject;
    [SerializeField] int maxNumberOfCorpses = 5;
    List<GameObject> playerCorpses = new List<GameObject>();

    // private IEnumerator spawnCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ResetPlayer()
    {
        SpawnCorpse();
        StartCoroutine(MovePlayerToSpawn());
    }

    IEnumerator MovePlayerToSpawn()
    {
        CharacterController playerController = player.GetComponent<CharacterController>();
        playerController.enabled = false;

        Vector3 spawnPosition = startingSpawn.transform.position;
        spawnPosition.y += spawnOffsetY;
        player.transform.position = spawnPosition;
        player.transform.rotation = Quaternion.identity;

        Rigidbody playerBody = player.GetComponentInChildren<Rigidbody>();
        playerBody.position = new Vector3(0,0,0);

        yield return new WaitForEndOfFrame();

        playerController.enabled = true;
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
