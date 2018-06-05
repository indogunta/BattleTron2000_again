using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObjects
{
    public GameObject spawnPoint;
    public GameObject target;
<<<<<<< HEAD

    public float bulletSpeed = 1000f;

=======
>>>>>>> kim
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

        Vector3 force = new Vector3(0, 0, zForce);

<<<<<<< HEAD
		rb.AddRelativeForce(force * bulletSpeed);
=======
        rb.AddForce(force, ForceMode.Impulse);
>>>>>>> kim
        
     
    }
}
