using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ObjectiveFinderAI : MonoBehaviour {

    [SerializeField]
    ListOfQuests loq;
    [SerializeField]
    TrailRenderer trail;

    public GameObject follow;
    public Transform warpPos;

   NavMeshAgent agent;
	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
       agent.SetDestination(follow.transform.position);
      
        if (Vector3.Distance(follow.transform.position,transform.position)< 31f)
        {
            //trail.Clear();
            agent.Warp(warpPos.position);
            agent.isStopped = true;
        }

      
    }
}
