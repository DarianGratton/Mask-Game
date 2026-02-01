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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPlayer();
    }

    public void ResetPlayer()
    {
        SpawnCorpse();
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        Vector3 playerPosition = startingSpawn.transform.position;
        playerPosition.y += spawnOffsetY;       
        player.transform.position = playerPosition;
        player.transform.rotation = Quaternion.identity;
    }

    public void SpawnCorpse()
    {
        GameObject newCorpse = Instantiate(corpseObject, player.transform.localPosition, player.transform.rotation);
        if (playerCorpses.Count >= maxNumberOfCorpses)
        {
            GameObject playerCorpse = playerCorpses[0];
            playerCorpses.RemoveAt(0);
            Destroy(playerCorpse);
        }
        playerCorpses.Add(newCorpse);
    }
}
