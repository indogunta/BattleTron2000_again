using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListOfQuests : MonoBehaviour
{
    
    public List<Objectives> AllQuests;
    [Header("End of List")]

    public static ListOfQuests Instance;

    public int questIndex = 0;

    public Text questTimer;
    public Text quest;

    public bool quitCountDown = false;
    bool skip = false;
    public void Start()
    {
        ListOfQuests.Instance = this;
        AllQuests[0].StartedQuest = true;
        quest.text = AllQuests[0].quest;
    }

    public void QuestCompleted()
    {

        if (questIndex < AllQuests.Count -1)
        {
            
            AllQuests[questIndex].IsComplete = true;
            AllQuests[++questIndex].StartedQuest = true;
            quest.text = AllQuests[questIndex].quest;
           
        }
    } 

    public void startCountDown(float timer)
    {
       
        StartCoroutine(CountDown(timer));
    }

    IEnumerator CountDown(float timer)
    {
        for(float i = timer; i > 0; i--)
        {
            questTimer.text = string.Format("{0:D2}:{1:D2}", (int)(i / 60 % 60), (int)(i % 60));
            if (quitCountDown)
            {
                quitCountDown = false;
                skip = true;
                break;
            }
            yield return new WaitForSeconds(1);
        }
       
        if (questIndex < AllQuests.Count - 1 && !skip)
        {
            QuestCompleted();
        }
        questTimer.text = "";
    }

    public void destroyedObject()
    {
        if(AllQuests[questIndex].myTargets.Count == 0)
        {
            QuestCompleted();
        }
    }
}
