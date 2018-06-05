using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public delegate void EveryonesHealth(int currentHealth);
    public EveryonesHealth everyonesHealth;
    [SerializeField]
    private int maxHealth;
    public int currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (everyonesHealth != null)
        {
            everyonesHealth(currentHealth);
        }
        currentHealth = ClampedHealth();
        Death();
    }

    int ClampedHealth()
    {
        return Mathf.Clamp(currentHealth, 0, maxHealth);
        // return currentHealth;
    }

    void Death()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
