﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Health enemyHealth;
    public PlayerManager player;

    [SerializeField]
    private Text pointsUI;

    public int enemyWorth;
    // Use this for initialization
    void Start()
    {
        player.playerPoints += AddPoints;
    }

    void AddPoints(int updatePoints)
    {
        if(enemyHealth.currentHealth <= 0 /*&& player != null*/)
        {
            
            pointsUI.text = "Points: " + updatePoints;
        }
    }

    // Update is called once per frame
}
