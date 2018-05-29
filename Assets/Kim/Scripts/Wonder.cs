using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonder : MonoBehaviour
{
    [SerializeField]
    private float radius;
    [SerializeField]
    private float jitter;
    [SerializeField]
    private float dis;
    [SerializeField]
    private Vector3 target;
  
    public Vector3 Wandering()
    {
        target = Vector3.zero;
        target = Random.insideUnitCircle.normalized * radius;
        target = (Vector2)target + Random.insideUnitCircle * jitter;
        target.z = target.y;
        target += transform.position;
        target += transform.forward * dis;
        target.y = transform.position.y;

        return target;
    }
}
