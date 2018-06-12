using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public void Attacking()
    {

        GameObject bullet = (GameObject)BulletPool.Instance.SpawnFromPool("Bullets", transform.position, Quaternion.identity);

        Instantiate(bullet);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 4000 ,ForceMode.Impulse);
    }

}
