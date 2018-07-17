using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Light))]
public class VolumeLights : MonoBehaviour {


    private MeshFilter filter;
    private Light litboi;

    private Mesh mesh;


	// Use this for initialization
	void Start ()
    {
        filter = GetComponent<MeshFilter>();
        litboi = GetComponent<Light>();
        if (litboi.type != LightType.Spot)
        {
            Debug.LogError("Please attach to a spotlight");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        mesh = BuildMesh();
        filter.mesh = mesh;
	}

    private Mesh BuildMesh()
    {
        mesh = new Mesh();
        float farPosition = Mathf.Tan(litboi.spotAngle) * litboi.range;

        return mesh;
    }
}
