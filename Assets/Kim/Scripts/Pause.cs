using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool paused = false;
    public GameObject pauseMenu;
    //public Animator pauseAnim;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Paused();
             //   Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Resume();
              //  Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    void Resume()
    {
               // pauseAnim.SetTrigger("Unpause");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = true;
    }

    void Paused()
    {
            //    pauseAnim.SetTrigger("Pause");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = false;
    }

}
