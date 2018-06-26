using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public Health playerHealth;
    // Use this for initialization
    void Start()
    {
        playerHealth.everyonesHealth += IsDead;
    }

    void IsDead(int currentHealth)
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
