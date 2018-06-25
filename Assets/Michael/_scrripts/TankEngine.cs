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

   [Header("car speed stuff")]

    public float maxMotorTorque = 800f;
    public float currentSpeed;
    public float maxSpeed = 200f;
    public Vector3 cenerOfMass;

    [Header("sensors")]
    public float sensorLemgth = 5.0f;
    public Transform sensorStartPos;
    public float frontSideSensorOffset = 5f;
    public float frontSensorngle = 35f;

    [Header("player attack stuff")]
    //public SphereCollider playerDetector;
    public GameObject player;   
    public float attackDistance;

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
        Sensors();
        ApplySteer();
        Drive();
        FindWaypointDist();

    }

    void Sensors()
    {
        RaycastHit hit;

        Vector3 SensorStartPos = sensorStartPos.transform.position;
        //front center sensor
        if (Physics.Raycast(SensorStartPos, transform.forward,out hit, sensorLemgth))
        {
        }
        //Debug.DrawLine(SensorStartPos, hit.point);

        //front right sensors
        SensorStartPos.x += frontSideSensorOffset;
        if (Physics.Raycast(SensorStartPos, transform.forward, out hit, sensorLemgth))
        {
        }
      //  Debug.DrawLine(SensorStartPos, hit.point);
        //front angle sensor
        if (Physics.Raycast(SensorStartPos, Quaternion.AngleAxis(frontSensorngle, transform.up)* transform.forward, out hit, sensorLemgth))
        {
        }
      //  Debug.DrawLine(SensorStartPos, hit.point);




        //front left sensors
        SensorStartPos.x -= 2* frontSideSensorOffset;
        if (Physics.Raycast(SensorStartPos, transform.forward, out hit, sensorLemgth))
        {
        }
      //  Debug.DrawLine(SensorStartPos, hit.point);
        //front left angle sensor
        if (Physics.Raycast(SensorStartPos, Quaternion.AngleAxis(-frontSensorngle, transform.up) * transform.forward, out hit, sensorLemgth))
        {
        }
      //  Debug.DrawLine(SensorStartPos, hit.point);
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
                print("current node " + currentnode);
            }
        }

    }

    void OnTiggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print(nodes.Count + other.gameObject.name);
            nodes.Add(other.transform);
            print(nodes.Count + other.gameObject.name);
        }
    }

    void OnDrawGizmos()
    {
        Color color = Color.blue;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, 200f);
    }
}
