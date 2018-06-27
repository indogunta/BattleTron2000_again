using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterScript : MonoBehaviour {

    public float thrusterStrength;
    public float thrusterDistance;
    public Transform[] thrusters;
   
    public LayerMask mask;


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

			if (Physics.Raycast (thruster.position, -Vector3.up, out hit, thrusterDistance, mask)) 
			{
				distancePercentage = 1 - (hit.distance / thrusterDistance);

				downwardForce = transform.up * thrusterStrength * distancePercentage;

				downwardForce = downwardForce * Time.deltaTime * rb.mass;

				rb.AddForceAtPosition (downwardForce, thruster.position);

                

			}
            Debug.DrawLine(thruster.position, hit.point);

        }
	
    }

}
