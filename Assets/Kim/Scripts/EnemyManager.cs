using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Health enemyHealth;
    public PlayerManager player;

    public int points;
    // Use this for initialization
    void Start()
    {
        player.playerPoints += AddPoints;
    }

    void AddPoints(int points)
    {
        if(enemyHealth.currentHealth < 1 && player != null)
        {
            player.currentPoints += points;
        }
    }

    // Update is called once per frame
}
