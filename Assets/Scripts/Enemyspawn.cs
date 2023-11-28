using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour
{

    public GameObject enemyprefab;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = Instantiate(enemyprefab, transform.position, Quaternion.identity);
        }
        
    }

    
}
