using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObjects
{
    public GameObject spawnPoint;
    public GameObject target;

    // Use this for initialization
    public void onPooledObject()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        float xForce = target.transform.position.x;
        float zForce = transform.transform.position.z;

        Vector3 force = new Vector3(xForce, 0, zForce);

        GetComponent<Rigidbody>().AddForce(force);
    }
}
