using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolAI : MonoBehaviour
{

    [SerializeField]
    List<Transform> points;
    public NavMeshAgent enemy;
    //List<Transform> target;
    public Transform[] target;
    int i = 0;

    // Update is called once per frame
    void Update()
    {

        if (target[i].position == null)
        {
            enemy.SetDestination(target[i].position);
        }
        else
        if (Vector3.Distance(transform.position, target[i].position) >= 0.4f)
        {
            i++;
            if (i > target.Length)
            {
                i = 0;
            }
        }

    }
}
