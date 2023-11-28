using System.Collections;
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


    // Start is called before the first frame update
    void Start()
    {
        xMin = zMin = -squareOffmovement;
        zMax = xMax = -squareOffmovement;

        newLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3 (Xposition, Yposition, Zposition)) <= closeEnough)
        {
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
