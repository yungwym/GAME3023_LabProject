using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traveller : MonoBehaviour
{
    public string LastSpawnPointName
    {
        get;
        set;
    } = "";


    // Start is called before the first frame update
    void Start()
    {

        //Pre-processor Directives, function only runs if in Unity Editor 
#if UNITY_EDITOR
        DestroySelfIfNotOriginal();
#endif

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoadAction;
    }

    private void DestroySelfIfNotOriginal()
    {
       if (SpawnPoint.Player != this)
        {
            //Not original, must destroy 
            Destroy(gameObject);
        }
    }

    void OnSceneLoadAction(Scene scene, LoadSceneMode loadMode)
    {
        if (LastSpawnPointName != "")
        {
            //Find spawn point
            SpawnPoint[] spawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();

            foreach (SpawnPoint spawn in spawnPoints)
            {
                if (spawn.name == LastSpawnPointName)
                {
                    //Teleport to that spawnPoint
                    transform.position = spawn.transform.position;
                }
            }
        }
    }


    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoadAction;
        Debug.Log("Player Destroyed");
    }
}
