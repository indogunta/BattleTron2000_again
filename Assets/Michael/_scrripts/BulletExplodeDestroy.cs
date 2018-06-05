using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplodeDestroy : MonoBehaviour
{


	public GameObject explosion;
	public GameObject me;


	 public float count;

	void OnObjectSpawn()
	{
		me = GetComponent<GameObject>();
	}

	void OnTriggerEnter(Collider other)
	{
        
        Health health = other.GetComponent<Health>();
		StartCoroutine (Explode ());
        if (health != null)
        {
            health.currentHealth -= 1;
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
