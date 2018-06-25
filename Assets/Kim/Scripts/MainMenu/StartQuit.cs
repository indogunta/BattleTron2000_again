using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartQuit : MonoBehaviour
{
    public Animator animator;

    private string load;

    public void LevelChanging(string index)
    {
        load = index;
        Debug.Log(load);
        animator.SetTrigger("FadeOut");
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
