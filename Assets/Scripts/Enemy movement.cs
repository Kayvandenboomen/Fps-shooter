using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent badGuy;

    public float squareOffmovement = 20f;
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
    private float Xposition;
    private float Yposition;
    private float Zposition;

    public float closeEnough = 3f;
    public float sightRange = 10f; // Adjust the sight range as needed
    private Transform player;

    // Attack variables
    public int damageAmount = 5;

    void Start()
    {
        xMin = zMin = -squareOffmovement;
        zMax = xMax = squareOffmovement;

        newLocation();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming the player has the "Player" tag
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= sightRange)
        {
            // Player is within sight, start following
            badGuy.SetDestination(player.position);

           
        }
        else if (Vector3.Distance(transform.position, new Vector3(Xposition, Yposition, Zposition)) <= closeEnough)
        {
            // Player is not in sight, find a new location
            newLocation();
        }


    }
    public void newLocation()
    {
        Xposition = Random.Range(xMin, xMax);
        Yposition = transform.position.y;
        Zposition = Random.Range(zMin, zMax);
        badGuy.SetDestination(new Vector3(Xposition, Yposition, Zposition));
    }
}


