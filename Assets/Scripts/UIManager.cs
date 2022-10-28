using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Transform playerPosition;

    private void Start()
    {
        playerPosition = FindObjectOfType<PlayerMovement>().transform;
    }

    public void SaveButtonPressed()
    {
        GameSaveManager.Instance.playerPosition = playerPosition.position;
        GameSaveManager.Instance.SaveGame();
    }

}
