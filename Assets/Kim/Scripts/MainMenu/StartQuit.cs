using UnityEngine;
using UnityEngine.SceneManagement;



public class StartQuit : MonoBehaviour
{
    public Animator animator;

    private string load;

    public void LevelChanging(string index)
    {
        load = index;
        animator.SetTrigger("FadeOut");
    }

    public void onComplete()
    {
        SceneManager.LoadScene(load);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
