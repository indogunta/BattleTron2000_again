using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	public GameObject enemy;
    public bool startSpawn;
    public int spawnMax;
    public float TimeToWait;
    public float radius;
    public Transform spawnPoint;


    void Start()
    {
        spawnPoint.transform.position = this.transform.position;
    }
	void Update()
	{
		if (startSpawn != true) 
		{
            StartCoroutine("spawner");
		}

	}



	IEnumerator spawner()
	{
        int enemyCount = 0;
        startSpawn = true;
		while (true)
        {
            if (enemyCount < spawnMax)
            {
                yield return new WaitForSeconds(TimeToWait);

                 Vector3 Spawnpos = Random.insideUnitSphere * radius;
                 spawnPoint.transform.position =Spawnpos;



                Spawnpos.y = 15;
                GameObject spawnedEnemy = Instantiate(enemy, Spawnpos, Quaternion.identity);
                enemyCount++;
            }
            if(enemyCount >= spawnMax)
            {
                break;
            }   

        }
	}

}
