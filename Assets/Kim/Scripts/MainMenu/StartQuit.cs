using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartQuit : MonoBehaviour
{
    public Animator animator;
    public AudioSource buttonAudio;

    private string load;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void LevelChanging(string index)
    {
        load = index;
        Debug.Log(load);
        animator.SetTrigger("FadeOut");
        buttonAudio.Play();
    }

    public void onComplete()
    {
        Debug.Log(load);
        StartCoroutine(AsyncLoad(load));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator  AsyncLoad(string load)
    {
        Debug.Log("trying to load:" + load);
        AsyncOperation async = SceneManager.LoadSceneAsync(load);
        while(!async.isDone)
        {
            Debug.Log(async.progress);
            yield return null;
        }
    }
}
