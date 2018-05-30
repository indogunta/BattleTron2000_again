using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterScript : MonoBehaviour {

    public float thrusterStrength;
    public float thrusterDistance;
    public Transform[] thrusters;
	public TrailRenderer[] trails;



    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        foreach(Transform thruster in thrusters)
        {
            Vector3 downwardForce;
            float distancePercentage;

			if (Physics.Raycast (thruster.position, thruster.up * -1, out hit, thrusterDistance)) 
			{
				distancePercentage = 1 - (hit.distance / thrusterDistance);

				downwardForce = transform.up * thrusterStrength * distancePercentage;

				downwardForce = downwardForce * Time.deltaTime * rb.mass;

				rb.AddForceAtPosition (downwardForce, thruster.position);


			}

		
        }
		foreach (TrailRenderer trail in trails)
		{
			trail.startColor = Color.blue;
		}
    }

}
