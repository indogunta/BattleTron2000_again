using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartQuit : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fadeToLevel(1);
        }
    }

    public void fadeToLevel(int index)
    {
        levelToLoad = index;
        animator.SetTrigger("Fading");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
