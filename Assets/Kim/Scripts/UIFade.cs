using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFade : MonoBehaviour
{
    public Animator enemyHealthAnimator;
    public Health enemyHealth; 
    // Use this for initialization
    void Start()
    {
        enemyHealth.everyonesHealth += Animation;
    }

    void Animation(int health)
    {
        if (health >= 0)
        {
            enemyHealthAnimator.SetTrigger("Fade");
        }
    }
}
