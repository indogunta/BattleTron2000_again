using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    TankController Tk;
    EnemyAI AI;
    private Transform target;

    public void Start()
    {
        //target = AI.player.transform;
    }
    public void Attacking()
    {

       
        //BulletPool.Instance.SpawnFromPool("Bullets", transform.position, Quaternion.identity);


        GameObject bullet = (GameObject)BulletPool.Instance.SpawnFromPool("Bullets", transform.position, Quaternion.identity);

        Instantiate(bullet);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 4000 ,ForceMode.Impulse);

    }

}
