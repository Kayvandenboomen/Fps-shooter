using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private TMP_Text Health;

    public TMP_Text health;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    void UpdateHealthUI()
    {
        if (Health != null)
        {
            Health.text = "Health: " + currentHealth.ToString();
        }
    }
}



