using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]


public class Meshgenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        Createshape();
        Updatemesh();
    }


    void Createshape()
    {
        vertices = new Vector3[]
        {
            new Vector3(0.0f,0f,2.0f),
            new Vector3(4.0f,4.0f,2.0f),
            new Vector3(0.0f,4.0f,2.0f),
            new Vector3(0.0f,4.0f,0.0f),
            new Vector3(0.0f,0.0f,2.0f),
            new Vector3(2.0f,0.0f,2.0f)
        };


        triangles = new int[]
        {
            2,4,3,
             2,1,2,
              2,1,0
        };
        
    }
     void Updatemesh()
        {
            mesh.Clear();

            mesh.vertices = vertices;
            mesh.triangles = triangles;
        }
    }

