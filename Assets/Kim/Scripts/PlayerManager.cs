using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public delegate void PlayerPoints(int points);
    public PlayerPoints playerPoints;
   // public EnemyManager enemy;

    public int currentPoints = 0;


    public void addPoints(int addedPoints)
    {
        currentPoints += addedPoints;

        playerPoints(currentPoints);
    }

    public void Update()
    {
        //if (playerPoints != null)
        //{
        //    playerPoints(currentPoints);
        //}
    }
}
