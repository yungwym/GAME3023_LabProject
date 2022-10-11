using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    //This object type will teleport any Player to a specificed scene and location within that scene


    [SerializeField]
    private string destinationSpawn = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Traveller traveller = collision.GetComponent<Traveller>();

        if (traveller != null)
        {
            traveller.LastSpawnPointName = destinationSpawn;

            SceneManager.LoadScene(gameObject.tag + "Scene", LoadSceneMode.Single);
        }
    }
}
