using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOne : MonoBehaviour {

    public Health playerHealth;

	// Use this for initialization
	void Start () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        playerHealth.BeenHit(-1);
    }
}
