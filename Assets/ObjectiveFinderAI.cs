﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ObjectiveFinderAI : MonoBehaviour {

    [SerializeField]
    ListOfQuests loq;

    public GameObject follow;

   NavMeshAgent agent;
	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
       agent.SetDestination(follow.transform.position);
    }
}
