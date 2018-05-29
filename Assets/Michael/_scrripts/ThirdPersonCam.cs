using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{

   // public Transform lookAt;
   // public Transform camTransform;


	public float smoothSoeed = .125f;
	public Vector3 offset;


    private Camera cam;


    private void Start()
    {
     //   camTransform = transform;
        cam = Camera.main;

    }

	private void FixedUpdate()
	{
		Vector3 CamlookPosition = transform.position + offset;
		Vector3 SmoothedPos = Vector3.Lerp (transform.position, CamlookPosition, smoothSoeed);
		transform.position = SmoothedPos;
	}


}
