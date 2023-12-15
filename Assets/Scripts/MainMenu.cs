using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Startgame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
