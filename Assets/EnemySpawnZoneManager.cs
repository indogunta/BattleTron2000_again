using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnZoneManager : MonoBehaviour {


    public GameObject[] EnemyPrefabs;

    public Transform[] SpawnPoints;

    void OnTriggerEnter()
    {
        foreach (var spawnPoint in SpawnPoints)
        {
            Instantiate(EnemyPrefabs[SpawnPoints.Length]);

        }
    }

}
