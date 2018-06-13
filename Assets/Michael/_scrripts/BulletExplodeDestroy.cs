using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplodeDestroy : MonoBehaviour
{

	public GameObject explosion;
	public GameObject me;
    public Light light;
	 public float count;
     public int damage = 1;

    public PlayerManager player;
    
	void OnObjectSpawn()
	{
		me = GetComponent<GameObject>();
       light = GetComponent<Light>();
    }

   
	void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Enemy"))
        {
            light.intensity = 0;
            Health health = other.GetComponent<Health>();
          
            StartCoroutine(Explode());
            if (health != null)
            {
                health.BeenHit(damage);
              //  player.AddPoints();
                //health.currentHealth -= damage;
            }

        }
    }

	void Update()
	{
		count -= Time.deltaTime;
		if (count <= 0f) 
		{
			Destroy (gameObject.gameObject);
            

		}
	}
	 
	IEnumerator Explode()
	{
		GameObject spawnedExplosion = Instantiate (explosion, transform.position, Quaternion.identity);
		yield return new WaitForSeconds (count);
		Destroy (spawnedExplosion);
	}

}
