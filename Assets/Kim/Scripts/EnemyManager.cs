using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

   // public Health enemyHealth;
    public PlayerManager player;

    public static EnemyManager instance;


    public int enemyWorth;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("There was a second Manager. I kileld him");
            Destroy(this); }
    }

    // Use this for initialization
    void Start()
    {
       // player.playerPoints += AddPoints;
    }


   public void AddPoints(int addedPoints)
    {
        //if (enemyHealth.currentHealth <= 0 /*&& player != null*/)
        //{
            //playeplayer += enemyWorth;
            player.addPoints(addedPoints);
        //}
	}




    //  public Health enemyHealth;
    //  public PlayerManager player;

    //  [SerializeField]
    //  private Text pointsUI;

    //  public int enemyWorth;
    //  // Use this for initialization
    //  void Start()
    //  {
    //      player.playerPoints += AddPoints;
    //  }

    //public  void AddPoints(int updatePoints)
    //  {
    //      if(enemyHealth.currentHealth <= 0 /*&& player != null*/)
    //      {

    //          pointsUI.text = "Points: " + updatePoints;
    //      }
    //  }

    //  // Update is called once per frame
}
