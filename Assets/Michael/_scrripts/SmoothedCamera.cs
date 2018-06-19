using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothedCamera : MonoBehaviour {

    public Transform target;

    public float smoothSpeed;

    public Vector3 offset;

	void Update () {

        Vector3 worldOff = target.TransformVector(offset);
        Vector3 targetpos = target.position + worldOff;
        Vector3 desiredPos = Vector3.Lerp(transform.position, targetpos, Time.deltaTime * smoothSpeed);
        transform.position = desiredPos;

        transform.LookAt(target);

	}
}
