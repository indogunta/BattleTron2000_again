using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    
	public GameObject bulletSpawnPoint;
    [System.Serializable]
    public class Pool 
    {
        public string tag; 
        public GameObject prefab;
        public int MaxNumberOfObjects;
        public Rigidbody rigidBody;
        //public Pool(Rigidbody rb)
        //{
        //    rigidBody = rb;
        //}
      
    }

    #region Singleton
    public static BulletPool Instance;

    private void Awake()
    {
       BulletPool. Instance = this;
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
            pool.rigidBody = pool.prefab.GetComponent<Rigidbody>();
            for(int i = 0; i < pool.MaxNumberOfObjects; i++)
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

		position = bulletSpawnPoint.transform.position;
		rotation = bulletSpawnPoint.transform.rotation;

        if(!Bullets.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " Does not exsit" );
            return null;
        }
	//	Debug.Log (System.Environment.StackTrace);
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
