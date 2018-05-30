using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObjects
{
    public GameObject spawnPoint;
    public GameObject target;

    public float bulletSpeed = 100f;

    private Rigidbody rb;

    void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    public void onPooledObject()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        OnObjectSpawn();
        //float xForce = transform.position.x*10;
        float zForce = 100;

        Vector3 force = new Vector3(0, 0, -zForce);

        rb.AddForce(force);
        
     
    }
}
