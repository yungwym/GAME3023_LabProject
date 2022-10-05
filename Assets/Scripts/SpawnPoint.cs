using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns player if there isnt one 
/// </summary>

public class SpawnPoint : MonoBehaviour
{

    [SerializeField]
    GameObject playerPrefab;

    public static Traveller Player
    {
        get;
        private set;
    }


    // Start is called before the first frame update
    void Awake()
    {
        if (Player == null && playerPrefab != null)
        {
            GameObject newPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity); //The original Player
            Player = newPlayer.GetComponent<Traveller>();
        }
    }
}

  
