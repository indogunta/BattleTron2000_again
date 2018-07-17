using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ListOfQuests : MonoBehaviour
{

    public delegate void delTimerCompleted();
    public PlayerManager playerManager;
    public GameObject marker;

    public List<Objectives> AllQuests;

    public AudioSource Source;

    public static ListOfQuests Instance;

    [Header("End of List")]
    public int questIndex = 0; //keeps track as to what quest the player is on

    public Text questTimer;
    public Text quest;

    public bool quitCountDown = false;

    public delTimerCompleted TimerCompleted;

    public void Start()
    {

        ListOfQuests.Instance = this;
        AllQuests[0].StartedQuest = true; //makes the first quest start instantly
        quest.text = AllQuests[0].quest; //sets the name of the quest to the UI
    }

    public void QuestCompleted() //completes the quest
    {
        AllQuests[questIndex].IsComplete = true;
        if (questIndex < AllQuests.Count - 1)
        {
            AllQuests[++questIndex].StartedQuest = true;
            quest.text = AllQuests[questIndex].quest;
        }
        else
        {
            if (playerManager.currentPoints >= PlayerPrefs.GetInt("Score", 0))
            {
                PlayerPrefs.SetInt("Score", playerManager.currentPoints);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene("EndScreen");
        }
    }

    public void startCountDown(float timer) //start the count down if there is one
    {

        StartCoroutine(CountDown(timer));
    }

    IEnumerator CountDown(float timer) //handles the count down
    {
        for (float i = timer; i > 0; i--)
        {
            questTimer.text = string.Format("{0:D2}:{1:D2}", (int)(i / 60 % 60), (int)(i % 60)); //updates a timer UI
            if (quitCountDown) //breaks out of the timer for the next quest
            {
                quitCountDown = false;
                break;
            }
            if(i == 1)
             {
                 QuestCompleted();
             }
            yield return new WaitForSeconds(1);
        }
        questTimer.text = "";
    }

}
