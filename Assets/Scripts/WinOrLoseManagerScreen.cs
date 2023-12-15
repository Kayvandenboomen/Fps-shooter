using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    void Start()
    {
        // Initially, hide the game over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
       
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ShowGameOverScreen()
    {
        // Show the game over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}


