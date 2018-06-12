using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Health health;
    public Image enemyHealthUI;
    public CanvasGroup enemyCanvas;
    public Transform player;
    // Use this for initialization
    void Start()
    {
        health.everyonesHealth += UpdateEnemyUI;
    }
    private void Update()
    {
        enemyCanvas.transform.rotation = Quaternion.LookRotation(enemyCanvas.transform.position - player.position);

    }
    void UpdateEnemyUI(int updatedHealth)
    {
        enemyHealthUI.fillAmount = (1f / health.maxHealth) * (health.currentHealth);
    }
}
