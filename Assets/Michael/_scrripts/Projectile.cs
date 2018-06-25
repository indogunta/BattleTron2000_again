using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 420f;
    public int predictionStepsPerFrame = 6;

    public Vector3 bulletVel;

    void Start()
        {
             bulletVel = this.transform.forward * speed;
        }

    void Update()
    {
        Vector3 point1 = this.transform.position;
        float stepSize = 1.0f / predictionStepsPerFrame;
        for (float step = 0; step < 1; step += stepSize)
        {
            bulletVel += Physics.gravity * stepSize * Time.deltaTime; ;
            Vector3 point2 = point1 + bulletVel * stepSize *Time.deltaTime;

            Ray ray = new Ray(point1, point2 - point1);


            //if (Physics.Raycast(ray, (point2 - point1).magnitude))
            //{
            //    //Debug.Log("Hit");
            //}

            point1 = point2;
            
        }
        this.transform.position = point1;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Vector3 point1 = this.transform.position;
        Vector3 PredictedBulledSpeed = bulletVel;
        float stepSize = 0.01f;
        for (float step = 0; step < 1; step+= stepSize)
        {
            PredictedBulledSpeed += Physics.gravity * stepSize;
            Vector3 point2 = point1 + PredictedBulledSpeed * stepSize;
            Gizmos.DrawLine(point1, point2);
            point1 = point2;
        }
    }

}
