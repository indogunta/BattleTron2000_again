using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public delegate void PlayerPoints(int points);
    public PlayerPoints playerPoints;

    public int currentPoints;

    public void Update()
    {
        playerPoints(currentPoints);
    }
}
