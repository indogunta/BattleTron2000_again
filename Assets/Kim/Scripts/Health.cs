using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public delegate void EveryonesHealth(int currentHealth);
    public EveryonesHealth everyonesHealth;

    public int maxHealth;
    public int currentHealth { get; private set; }

    public GameObject destructable;
    public Transform destructableSpawnPoint;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void BeenHit(int Damage)
    {
        currentHealth -= Damage;
        EveryonesHealth healthDelegate = everyonesHealth;
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
            ListOfQuests.Instance.AllQuests[ListOfQuests.Instance.questIndex].CheckTargets(gameObject);

            Destroy(gameObject);
            Instantiate(destructable, destructableSpawnPoint.transform.position, destructableSpawnPoint.transform.rotation );
            StartCoroutine(KillParts());
        }
    }

    IEnumerator KillParts()
    {
        yield return new WaitForSeconds(3);
        Destroy(destructable.gameObject.gameObject);
    }
}
