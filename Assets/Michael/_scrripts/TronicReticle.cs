using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TronicReticle : MonoBehaviour {

    public float reticleDistance;

    public Transform reticle;

    private LineRenderer lr;



    private void OnValidate()
    {
        lr = GetComponent<LineRenderer>();
        if(reticle != null)
        {
            reticle.position = transform.position + -transform.forward * reticleDistance;
        }
    }

    private void Awake()
    {
        lr.positionCount = 2;
    }

    private void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + -transform.forward * reticleDistance);
    }

}
