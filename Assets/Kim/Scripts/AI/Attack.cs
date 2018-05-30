using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public void Attacking()
    {
        BulletPool.Instance.SpawnFromPool("Bullets", transform.position, Quaternion.identity);
    }

    //public void Attack()
    //{
    //    GameObject bullet = 
    //}
}
