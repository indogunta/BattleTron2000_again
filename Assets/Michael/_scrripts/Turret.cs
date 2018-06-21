using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turningRate;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private GameObject barrelTip;
    //private GameObject temp;
    public float attackDistance;
    private Vector3 barrelForward;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        { 
			
                // .. if it's enemy, look at it and shoot it
                transform.LookAt(other.transform);
				barrelForward = barrelTip.transform.forward;
                StartCoroutine("Fire");
        }
        
    }

    void Update()
    {
       
        Debug.DrawLine(transform.position, target.transform.position, Color.red);

      

        if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)

        {

            transform.LookAt(target.transform);
            barrelForward = barrelTip.transform.forward;
           StartCoroutine("Fire");
        }




    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            // .. if it's enemy, look at it and shoot it
            transform.LookAt(other.transform);
            barrelForward = barrelTip.transform.forward;
            StartCoroutine("Fire");
        }

    }




    void FireTurret()
    {
        // Instantiate the bullets as gameObjects
        var bullet = Instantiate(projectile, barrelTip.transform.position, Quaternion.identity) as GameObject;
        // Add the impulse force to make the bullets move
        bullet.GetComponent<Rigidbody>().AddForce(barrelForward * 1000f, ForceMode.Impulse);
    }

    // So that each bullet has a delay between it being fired
    IEnumerator FireDelay()
    {
	
		yield return new WaitForSeconds(speed);
        FireTurret();
    }
    IEnumerator Fire()
    {
        yield return StartCoroutine("FireTurret");
    }
}