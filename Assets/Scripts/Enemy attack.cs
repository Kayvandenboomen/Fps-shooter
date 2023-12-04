using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyattack : MonoBehaviour
{
    public Transform Player;
    public float AttackRange = 2f;
    public int damageAmount = 5;

    private Enemy enemyScript;
    public Renderer ren;
    public Material defaultMaterial;
    public Material alertMaterial;

    private bool foundPlayer;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyScript = GetComponent<Enemy>(); // Assuming you have an Enemy script on the same GameObject
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= AttackRange)
        {
            // Log to check if the condition is met
            Debug.Log("Within Attack Range");

            ren.sharedMaterial = alertMaterial;
            enemyScript.badGuy.SetDestination(Player.position);
            foundPlayer = true;

            // Deal damage to the player
            DealDamageToPlayer();
        }
        else if (foundPlayer)
        {
            ren.sharedMaterial = defaultMaterial;
            enemyScript.newLocation();
            foundPlayer = false;
        }
    }

    void DealDamageToPlayer()
    {
        // Assuming your player has a PlayerHealth script attached
        Playerhealth playerHealth = Player.GetComponent<Playerhealth>();

        if (playerHealth != null)
        {
            // Deal damage to the player
            playerHealth.TakeDamage(damageAmount);
        }
        else
        {
            Debug.LogWarning("Playerhealth script not found on the player GameObject.");
        }
    }
}