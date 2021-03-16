using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public void startGame() {
        SceneManager.LoadScene(1);
    }

    public void openSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void exit() {
        Application.Quit();
    }
}
