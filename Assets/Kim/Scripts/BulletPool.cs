using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    

    [System.Serializable]
    public class Pool 
    {
        public string tag; 
        public GameObject prefab;
        public int size;
        public GameObject[] objs;
    }

    #region Singleton
    public static BulletPool Instance;

    private void Awake()
    {
        Instance = this;
    }

#endregion

    public List<Pool> pools; 
    public Dictionary<string, Queue<GameObject>> Bullets;

    void Start()
    {
        Bullets = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            Bullets.Add(pool.tag, objectPool);
        }

       
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(!Bullets.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " Does not exsit" );
            return null;
        }
        GameObject objToSpawn = Bullets[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        IPooledObjects pooledObjects = objToSpawn.GetComponent<IPooledObjects>();
        if(pooledObjects != null)
        {
            pooledObjects.onPooledObject();
        }

        Bullets[tag].Enqueue(objToSpawn);
        return objToSpawn;
    }
}
