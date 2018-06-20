using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemyPursiut : MonoBehaviour {

    [SerializeField]
    Transform destomation;
    NavMeshAgent agent;

	// Use this for initialization
	void Start ()
    {
        agent = this.GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            return;
        }
        else
        {
            SetDestination();
        }
	}

    private void SetDestination()
    {
        if (destomation != null)
        {
            Vector3 targetVec = destomation.transform.position;
            agent.SetDestination(targetVec);
        }
    }
}
