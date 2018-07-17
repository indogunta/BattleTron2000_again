using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartQuit : MonoBehaviour
{
    public Animator animator;
    public Animator loading;
    public GameObject loadingImage;
    public AudioSource buttonAudio;

    private string load;

    private void Awake()
    {

        //Cursor.visible = true;
       // Cursor.lockState = CursorLockMode.Locked;

        //Cursor.visible = true;
        loadingImage.SetActive(false);
        //Cursor.lockState = CursorLockMode.None;

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
        if (loading != null || loadingImage != null)
            {
                loadingImage.SetActive(true);
                loading.SetTrigger("isLoading");
            }


        yield return new WaitForSecondsRealtime(2.0f);

        AsyncOperation async = SceneManager.LoadSceneAsync(load);
        Debug.Log("trying to load:" + load);
        while (!async.isDone)
        {
           
            yield return null;
        }
    }
}
