using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public class clsTargetTags
{
    public string tag;
    public int qty;
    public int killcount;
}

[System.Serializable]
public class Objectives
{
    public string quest; // the name of the quest
    [SerializeField]

    [Header("Target Info")]
    public clsTargetTags[] TargetTags;
    public List<GameObject> myTargets; // sets the target of the the quest
    public bool isTimed = false; //Allows you to choose if the quest has a timer or not
    private bool _isComplete = false; 
    private bool startedQuest = false;
    [Header("Timer")]
    public float timer;

    public bool StartedQuest
    {
        get { return startedQuest; }
        set
        {
            startedQuest = value;
            if(!startedQuest)
            {
                return;
            }

            if(isTimed)
            {
                ListOfQuests.Instance.startCountDown(timer);
            }
        }
    }
    [SerializeField]
    public bool IsComplete
    {
        get { return _isComplete;}
        set
        {
            if(value)
            {
                startedQuest = false;
            }
            _isComplete = value;
        }
    }

    public void CheckTargets(GameObject target)
    {
        TargetTags.First<clsTargetTags>((x) => x.tag == target.tag).killcount++;
        myTargets.Remove(target);
        
    }
    
}
   
