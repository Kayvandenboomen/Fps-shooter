using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic_script : MonoBehaviour
{
  public static BackgroundMusic_script instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
