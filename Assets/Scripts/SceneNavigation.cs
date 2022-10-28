using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadGameScene()
    {
        GameSaveManager.Instance.playerPosition = new Vector3(0, 0, 0);
        SceneManager.LoadScene("OverworldScene");
    }


    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }


    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
        Application.Quit()

        #endif



    }

}
