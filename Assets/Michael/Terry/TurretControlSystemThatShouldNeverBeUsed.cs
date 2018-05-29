using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControlSystemThatShouldNeverBeUsed : MonoBehaviour
{
	public Transform turret;
	public Quaternion aimRotation;

	void Start()
	{
		aimRotation = turret.rotation;
	}

	void Update()
	{
		float turn = Input.GetAxisRaw ("Horizontal");

		transform.Rotate (transform.up, turn);

		// aim mode
		if (Input.GetAxisRaw ("Fire2") != 0.0f)
		{
			float turretTurn = Input.GetAxisRaw ("Mouse X");

			Quaternion newAimRotation = aimRotation * Quaternion.AngleAxis (turretTurn, turret.up);

			turret.rotation = aimRotation = newAimRotation;

			//turret.Rotate (Vector3.up, turretTurn);
		}
		// rest mode
		else
		{
			
		}
	}
}
