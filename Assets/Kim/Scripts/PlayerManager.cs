using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public delegate void PlayerPoints(int points);
    public PlayerPoints playerPoints;
   // public EnemyManager enemy;

    public int currentPoints = 0;
    private void Start()
    {
       
    }
    

    public void addPoints(int addedPoints)
    {
       
        currentPoints += addedPoints;

        playerPoints(currentPoints);
        PlayerPrefs.SetInt("PlayerScore", currentPoints);
      
        PlayerPrefs.Save();
    }


}
