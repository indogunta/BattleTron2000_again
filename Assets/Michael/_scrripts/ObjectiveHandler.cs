using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveHandler : MonoBehaviour 

{
	
	public Objectives currentObjective;

	void Start()
	{
		List<Objectives> obbys = new List<Objectives> ();
		currentObjective.isAchieved = false;
	}

	void CheckObjectives()
	{
		
	}


}
