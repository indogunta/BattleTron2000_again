using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObjects
{
    public GameObject spawnPoint;
    public GameObject target;
    private Rigidbody rb;

    void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        OnObjectSpawn();
    }
    // Use this for initialization
    public void onPooledObject()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        float zForce = 100;

        Vector3 force = new Vector3(0, 0, -zForce);

        rb.AddForce(force, ForceMode.Impulse);
        
     
    }
}
