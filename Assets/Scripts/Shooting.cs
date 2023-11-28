using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera cam;
    
    private RaycastHit hit;
    private Ray ray;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag.Equals("NPC"))
                {
                    Debug.Log("hit NPC");
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
