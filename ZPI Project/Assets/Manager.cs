using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    public void Singleplayer()
    {
        SceneManager.LoadScene(3);
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitApp()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
