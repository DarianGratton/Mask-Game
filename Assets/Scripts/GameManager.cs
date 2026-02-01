using System.Collections.Generic;
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

    private Vector3 startingSpawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SpawnPlayer();

        startingSpawnPos = startingSpawn.transform.position;
        startingSpawnPos.y += spawnOffsetY;
    }

    public void ResetPlayer()
    {
        SpawnCorpse();
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        Vector3 spawnPosition = startingSpawn.transform.position;
        spawnPosition.y += spawnOffsetY;       
        player.transform.position = startingSpawnPos;
        player.transform.rotation = Quaternion.identity;
    }

    public void SpawnCorpse()
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
