using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIngame : MonoBehaviour
{
    public int WinKillCount = 12;
    private TMP_Text KillScoress;

    public AudioSource WinSound;

    private void Gamewin()
    {
        if (WinKillCount == 12)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

}


