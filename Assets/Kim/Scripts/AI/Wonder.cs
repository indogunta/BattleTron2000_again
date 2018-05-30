using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wonder : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] target;
    int destPoints;
    // bool reached = true;
    // Use this for initialization
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = true;
        NextPoint();
    }
    public void NextPoint()
    {
        if (target.Length == 0)
        {
            return;
        }
        agent.destination = target[destPoints].position;
        destPoints = (destPoints + 1) % target.Length;
    }
}
