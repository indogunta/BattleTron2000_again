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
    private Slider healthUI;
    private void Start()
    {
        playerPoints.playerPoints += UpdatePointUI;
        playerHealth.everyonesHealth += UpdateHealthUI;
    }

    void UpdatePointUI(int points)
    {
        pointsUI.text = "Points: " + points;
    }

    void UpdateHealthUI(int currentHealth)
    {
        healthUI.value = currentHealth;
    }
}
