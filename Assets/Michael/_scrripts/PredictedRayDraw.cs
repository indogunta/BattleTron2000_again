using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedRayDraw : MonoBehaviour {


    public LineRenderer lineRender;

    public float speed = 420f;

    public int predictionStepsPerFrame = 6;

    public Vector3 bulletVelocity;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        lineRender.SetPosition(0, this.transform.position);
        lineRender.useWorldSpace = true;
        int count = 1;
        float stepSize = 1.0f / predictionStepsPerFrame;
        for (float step = 0; step < 1; step += .01f)
        {
            count++;
            bulletVelocity += Physics.gravity * stepSize;
            lineRender.SetPosition(count, bulletVelocity);

        }


    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Vector3 point1 = this.transform.position;
        Vector3 PredictedBulledSpeed = bulletVelocity;
        float stepSize = 0.01f;
        for (float step = 0; step < 1; step += stepSize)
        {
            PredictedBulledSpeed += Physics.gravity * stepSize;
            Vector3 point2 = point1 + PredictedBulledSpeed * stepSize;
            Gizmos.DrawLine(point1, point2);
            point1 = point2;
        }
    }
}
