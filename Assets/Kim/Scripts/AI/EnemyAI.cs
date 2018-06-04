using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyAIstates
{
    Wander, Target, Attack
}

public class EnemyAI : MonoBehaviour
{

    public static EnemyAI instance;
    private void Awake()
    {
        instance = this;
    }

    private float timer;
    private float dis;
    [SerializeField]
    private float minDis;
    [SerializeField]
    private float maxDis;
    //[SerializeField]
    public NavMeshAgent enemy;

    private EnemyAIstates currentState;

    [SerializeField]
    private Transform player;

    [SerializeField]
    public Attack attack;

    public OffsetPursuit pursuit;
    public Wonder wonder;

    private void Start()
    {
        attack = GetComponent<Attack>();
        pursuit = GetComponent<OffsetPursuit>();
        wonder = GetComponent<Wonder>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyAIstates.Wander:
                enemy.isStopped = false;
                if (!enemy.pathPending && enemy.remainingDistance < 0.5f)
                {
                    wonder.NextPoint();
                }
      
                break;
            case EnemyAIstates.Target:
                enemy.isStopped = false;
                enemy.destination = pursuit.Pursuit();
             
                break;
            case EnemyAIstates.Attack:
                attack.Attacking();
                enemy.isStopped = true;
              
                break;
        }
        SwitchStates();


    }

    private void SwitchStates()
    {
        dis = Vector3.Distance(enemy.transform.position, player.position);
        if (dis < minDis)
        {
            currentState = EnemyAIstates.Attack;
          
        }
        else if (dis > minDis && dis < maxDis)
        {
            currentState = EnemyAIstates.Target;
           
        }
        else
        {
            currentState = EnemyAIstates.Wander;
            
        }
    }
}
