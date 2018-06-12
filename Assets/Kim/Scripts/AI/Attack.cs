using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{


    public GameObject ammo;
    public Transform cannonEnd;
    public float bulletForce = 400f;
    public AudioSource bam;

    public void Attacking()
    {
 
        Shoot();
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(ammo, cannonEnd.transform.position, cannonEnd.transform.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();


       
        //BulletPool.Instance.SpawnFromPool("Bullets", transform.position, Quaternion.identity);


       // GameObject bullet = (GameObject)BulletPool.Instance.SpawnFromPool("Bullets", transform.position, Quaternion.identity);

        Instantiate(bullet);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 4000 ,ForceMode.Impulse);


        rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);

        bam.Play();

    }

}
