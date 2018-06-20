using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public PlayerManager playerPoints;
    public Health playerHealth;

    [SerializeField]
    private Text pointsUI;


    [SerializeField]
    private Image healthUI;
    private void Start()
    {
        playerHealth.everyonesHealth += UpdateHealthUI;
        playerPoints.playerPoints += UpdatePoints;
    }
    void UpdateHealthUI(int currentHealth)
    {
        healthUI.fillAmount = 1 / playerHealth.maxHealth * (currentHealth);
    }

    void UpdatePoints(int points)
    {
        pointsUI.text = "Points: " + points;
    }
}
