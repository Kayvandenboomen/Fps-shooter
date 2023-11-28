using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemyattack : MonoBehaviour
{
    public Transform Player;
    public float AttackRange = 6f;

    private Enemy enemyScript;
    

    public Renderer ren;
    public Material defaultMaterial;
    public Material alertMaterial;

    private bool foundPlayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position ) <= AttackRange)
        {
            ren.sharedMaterial = alertMaterial; //change material
            enemyScript.badGuy.SetDestination(Player.position); //chase position of the player
            foundPlayer = true;
        }
        else if (foundPlayer)
        {
            ren.sharedMaterial = defaultMaterial; //change material
            enemyScript.newLocation(); //continue on normal path
            foundPlayer = false;
        }
        
    }
}
