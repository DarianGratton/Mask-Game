using System.Collections.Generic;
using UnityEngine;

struct PlayerCorpse
{
    Vector3 transform;
    GameObject corpseObject;
}

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player;

    [Header("Spawn")]
    [SerializeField] GameObject startingSpawn;
    [SerializeField, Tooltip("Offset of the player on the y axis so they don't spawn right in the center of the spawn point.")] 
    float spawnOffsetY;

    // Corpses
    List<PlayerCorpse> playerCorpse = new List<PlayerCorpse>(); 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Vector3 playerPosition = startingSpawn.transform.position;
        playerPosition.y += spawnOffsetY;        
        player.transform.position = playerPosition;
    }


}
