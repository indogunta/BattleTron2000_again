using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Health enemyHealth;
    public PlayerManager player;

   
    public int enemyWorth;
    // Use this for initialization
    void Start()
    {
        player.playerPoints += AddPoints;
    }

    void AddPoints(int CurrentPoints)
    {
        if(enemyHealth.currentHealth <= 0 /*&& player != null*/)
        {
            CurrentPoints += enemyWorth;
        }
    }

    // Update is called once per frame
}
