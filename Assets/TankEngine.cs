using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEngine : MonoBehaviour {

    public Transform path;
    private List<Transform> nodes;
    private int currentnode;
    public float maxSteerAngle = 45f;
    public WheelCollider WheelFl;
    public WheelCollider WheelFr;
    public WheelCollider WheelBl;
    public WheelCollider WheelBr;


    public float maxMotorTorque = 800f;
    public float currentSpeed;
    public float maxSpeed = 200f;
    public Vector3 cenerOfMass;



    void Start()

    {
        GetComponent<Rigidbody>().centerOfMass = cenerOfMass;


        Transform[] patrolTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < patrolTransforms.Length; i++)
        {
            if (patrolTransforms[i] != transform)
            {
                nodes.Add(patrolTransforms[i]);
            }
        }
    }
    void FixedUpdate()
    {
        ApplySteer();
        Drive();
        FindWaypointDist();

    }
    void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentnode].position);
        float newSteer = (relativeVector.x /= relativeVector.magnitude)*maxSteerAngle;

        WheelFl.steerAngle = newSteer;
        WheelFr.steerAngle = newSteer;
    }
    void Drive()
    {
        currentSpeed = 2 * Mathf.PI * WheelFl.radius * WheelFl.rpm * 60 / 100;

        if (currentSpeed < maxSpeed)
        {
            WheelFl.motorTorque = maxMotorTorque;
            WheelFr.motorTorque = maxMotorTorque;
            WheelBl.motorTorque = maxMotorTorque;
            WheelBr.motorTorque = maxMotorTorque;
        }
        else
        {
            WheelFl.motorTorque = 0;
            WheelFr.motorTorque = 0;
            WheelBl.motorTorque = 0;
            WheelBr.motorTorque = 0;
        }


    

    }
    void FindWaypointDist()
    {
        if (Vector3.Distance(transform.position, nodes[currentnode].position) < 40f)
        {
            if (currentnode == nodes.Count - 1)
            {
                currentnode = 0;
            }
            else
            {
                currentnode++;
                print(currentnode);
            }
        }

    }
}
