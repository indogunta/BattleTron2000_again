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
    private float timer;
    private float dis;
    [SerializeField]
    private float minDis;
    [SerializeField]
    private float maxDis;
    [SerializeField]
    private NavMeshAgent enemy;

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
               enemy.destination = wonder.Wandering();
              //  Debug.Log("Player not seen: returning to wonder");
                break;
            case EnemyAIstates.Target:
                enemy.destination = pursuit.Pursuit();
              //  Debug.Log("Out of Range: Target not reachable; Continuing pursuit");
                break;
            case EnemyAIstates.Attack:
                attack.Attacking();
                enemy.destination = transform.position;
             //   Debug.Log("In Range: Attacking has initiated");
                break;
        }
        SwitchStates();
        Debug.DrawLine(enemy.destination, enemy.gameObject.transform.position,Color.blue);
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
