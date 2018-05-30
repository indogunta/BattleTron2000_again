using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursuit : MonoBehaviour
{
    public Rigidbody target;
    private Vector3 futurePoint;
    public float dividedDistance;


    public float ahead;
    private void Update()
    {
        Pursuit();
    }

    public Vector3 Pursuit()
    {
        float distance;
        distance = Vector3.Distance(target.position, transform.position);
        ahead = distance / dividedDistance;
        futurePoint = target.position + target.velocity * ahead;

        return futurePoint;
    }


    //public Vector3 leaderOffset;
    //public Transform leader;
    //Rigidbody rb;

    //public float speed;

    //// Use this for initialization
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    leaderOffset = leader.position - transform.position;
    //}

    //// Update is called once per frame
    //void Update()
    //{                       
    //    leaderOffset = transform.position - leader.transform.position;
    //    arrive(leaderOffset);

    //}
    //private void arrive(Vector3 targetPos)
    //{
    //    Vector3 targetY = targetPos;
    //    targetY.y = transform.position.y;
    //    Vector3 targetOffset = targetPos - transform.position;
    //    float dist = Vector3.Distance(transform.position, targetPos);
    //    float rampSpeed = speed * (targetOffset.magnitude / dist);
    //    float clippedSpeed = Mathf.Min(rampSpeed, speed);
    //    Vector3 desiredVelocity = (clippedSpeed / targetOffset.magnitude) * targetOffset;
    //    if (targetOffset.magnitude != 0)
    //    {
    //        desiredVelocity = ((clippedSpeed / targetOffset.magnitude) * targetOffset);
    //        rb.velocity = desiredVelocity;
    //    }

    //}
}
