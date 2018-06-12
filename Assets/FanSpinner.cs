using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpinner : MonoBehaviour {

    public WheelCollider targetWheel;
    private Vector3 wheelPos = new Vector3();
    private Quaternion wheelRotation = new Quaternion();

    void Update()
    {
        targetWheel.GetWorldPose(out wheelPos,  out wheelRotation );
        //transform.position = wheelPos;
       // transform.rotation = wheelRotation;
    }
	
}
