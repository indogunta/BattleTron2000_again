using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedSuicideScript : MonoBehaviour {


    public float killTime = 10f;
    // Use this for initialization

    void Start()
    {
        StartCoroutine(Suicide());
    }

    IEnumerator Suicide()
    {
        yield return new WaitForSeconds(killTime);
        Destroy (this.gameObject);
    }

}
