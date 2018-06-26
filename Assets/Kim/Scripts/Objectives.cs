using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public class clsTargetTags 
{
    public string tag;
    public int qty;
    public int killCount;
}

[System.Serializable]
public class Objectives
{
    public string quest; // the name of the quest also affects the UI for the quest name

    public AudioClip backgroundMusic;
    [Header("Target Info")]
    public clsTargetTags[] TargetTags; //use this if the player is to go to a destenation or if it does not matter what the player is attacking
    public List<GameObject> myTargets; // sets the target of the the quest
    public GameObject[] questMarker; //allows to place a marker on a gameobject

    [Header("Bools")]
    public bool isGameObject = false; //use this if the player is attacking something spacific 
    public bool isTimed = false; //Allows you to choose if the quest has a timer or not

    [Header("Timer")]
    public float timer;

    

    [Header("--E--------N--------D--")]
    [SerializeField]
    private bool _isComplete = false;
    private bool startedQuest = false;

    public bool StartedQuest //if the quest isComplete then start the next one
    {
        get { return startedQuest; }
        set
        {
            startedQuest = value;
            if (!startedQuest)
            {
                return;
            }
            ListOfQuests.Instance.Source.PlayOneShot(backgroundMusic, 1f);

            if (isTimed)
            {
                ListOfQuests.Instance.startCountDown(timer);
            }
        }
    }
    [SerializeField]
    public bool IsComplete //checks to see if the quest is complete if not then don't start next quest
    {
        get { return _isComplete; }
        set
        {
          
            if (value)
            {
                startedQuest = false;
            }
            _isComplete = value;
        }
    }

    public void CheckTargets(GameObject target) //lowers the size of the list or array, makes sure the the next quest starts once the size hits zero
    {
        if (isTimed)
        {
            if (TargetTags != null && TargetTags.Length > 0)
            {
                TargetTags.First<clsTargetTags>((x) => x.tag == target.tag).killCount++;
                if (TargetTags.First<clsTargetTags>().killCount == TargetTags.First<clsTargetTags>().qty)
                {
                    ListOfQuests.Instance.quitCountDown = true;
                    ListOfQuests.Instance.QuestCompleted();
                }
            }
            return;
        }

        if (isGameObject) 
        {
            for (int i = 0; i < questMarker.Length; i++)
            {
                questMarker[i].SetActive(true);
            }
            myTargets.Remove(target);
            if (myTargets.Count == 0)
            {
                ListOfQuests.Instance.QuestCompleted();
            }
        }

    }
}
   
