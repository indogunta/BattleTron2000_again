using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        ListOfQuests.Instance.QuestCompleted();
        Destroy(gameObject);
    }
}
