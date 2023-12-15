using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    public int maxEnemyKills = 12;
    private int currentEnemyKills = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnemyKilled()
    {
        currentEnemyKills++;

        if (currentEnemyKills >= maxEnemyKills)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        // Load the win scene
        SceneManager.LoadScene("WinScene");
    }
}
