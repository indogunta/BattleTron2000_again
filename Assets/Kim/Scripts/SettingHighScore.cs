using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingHighScore : MonoBehaviour
{
    public Text highScore;
    public Text currentScore;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("PlayerScore"))
        {
            highScore.text = "High Score: " + PlayerPrefs.GetInt("Score");
            currentScore.text = "Score: " + PlayerPrefs.GetInt("PlayerScore");
        }
    }
    //6300
    //6450
}
