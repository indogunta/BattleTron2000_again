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
    public string quest; // the name of the quest

    [Header("Target Info")]
    public clsTargetTags[] TargetTags;
    public List<GameObject> myTargets; // sets the target of the the quest

    [Header("Bools")]
    public bool isGameObject = false;
    public bool isTimed = false; //Allows you to choose if the quest has a timer or not

    [Header("Timer")]
    public float timer;
     private bool _isComplete = false;
    private bool startedQuest = false;

    public bool StartedQuest
    {
        get { return startedQuest; }
        set
        {
            startedQuest = value;
            if (!startedQuest)
            {
                return;
            }

            if (isTimed)
            {
                ListOfQuests.Instance.startCountDown(timer);
            }
        }
    }
    [SerializeField]
    public bool IsComplete
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

    public void CheckTargets(GameObject target)
    {
        if (TargetTags != null && TargetTags.Length > 0)
        {
            TargetTags.First<clsTargetTags>((x) => x.tag == target.tag).killCount++;
             if(TargetTags.First<clsTargetTags>().killCount == TargetTags.First<clsTargetTags>().qty)
            {
                ListOfQuests.Instance.QuestCompleted();
            }
        }
        myTargets.Remove(target);
        if (isGameObject)
        {
            ListOfQuests.Instance.destroyedObject();
        }

            ListOfQuests.Instance.quitCountDown = true;
        
        
    }

}
   
