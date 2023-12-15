using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public Camera cam;
    public AudioSource reloadSound; // Assign in the Unity Editor

    private RaycastHit hit;
    private Ray ray;

    private int currentAmmo = 10;
    private bool isReloading = false;
    private float reloadTime = 4f;

    private TMP_Text KillScoress;
    private int Score = 0;

    private GameManager gameManager;



    private void Awake()
    {
        KillScoress = GameObject.Find("KilledEnemies").GetComponent<TMP_Text>();
        gameManager = GameManager.instance;
    }

        // Start is called before the first frame update
        void Start()
    {
        if (!reloadSound)
        {
            reloadSound = gameObject.AddComponent<AudioSource>();
        }
        

    }

    // Update is called once per frame
    void Update()
    {

        //// Ensure that an AudioSource component is attached to the GameObject

        //if (isReloading)
        //{
        //    if (!reloadSound.isPlaying)
        //    {
        //        reloadSound.Play(); // Play the reload sound only once when reloading starts
        //    }
        //    return; // If reloading, do not process shooting
        //}

        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo <= 0)
            {

                StartCoroutine(Reload());
            }
            else
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Shot fired!");

            // Regardless of hitting an NPC or not, deduct ammo
            currentAmmo--;
            Debug.Log("Ammo left: " + currentAmmo);

            if (hit.collider.tag.Equals("NPC"))
            {
                Debug.Log("Hit NPC");
                Destroy(hit.collider.gameObject);
                KillEnemyCount();
                gameManager.EnemyKilled();
            }
        }
    }

    public void KillEnemyCount()
    {
        Score++;
        Debug.Log(Score + " Enemies killed");
        KillScoress.text = "Enemy Kills: " + Score;
        if (Score > 11) {
        
        Debug.Log("you win");
            SceneManager.LoadScene("Winscene");
    }
    } 


    IEnumerator Reload()
    {
       
        Debug.Log("Reloading...");

        if (reloadSound)
        {
            reloadSound.Play(); // Play the reload sound only when reloading
        }
      

        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = 10; // Reloaded, set ammo back to 10
        isReloading = false;
        Debug.Log("Reload complete. Ammo: " + currentAmmo);
    }
}