using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    public Transform Player;
    public float AttackRange = 2f;
    public int damageAmount = 5;
    public float attackCooldown = 6f;

    private Enemy enemyScript;
    private Renderer ren;
    private Material defaultMaterial;
    private Material alertMaterial;

    private bool foundPlayer;
    private float lastAttackTime;

    public NavMeshAgent badGuy;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyScript = GetComponent<Enemy>();
        ren = GetComponent<Renderer>();
        defaultMaterial = ren.material;
    }

    void Update()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            if (Vector3.Distance(transform.position, Player.position) <= AttackRange)
            {
                Debug.Log("Within Attack Range");
                ren.sharedMaterial = alertMaterial;
                enemyScript.badGuy.SetDestination(Player.position);
                foundPlayer = true;
                AttackPlayer();
                lastAttackTime = Time.time;
            }
            else if (foundPlayer)
            {
                ren.sharedMaterial = defaultMaterial;
                enemyScript.newLocation();
                foundPlayer = false;
            }
        }
    }

    void AttackPlayer()
    {
        PlayerHealth playerHealth = Player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);

            if (playerHealth.IsDead())
            {
                // Handle game over logic here
                Debug.Log("Player has died!");
                SceneManager.LoadScene("GameOverScreen");
            }
        }
    }
}