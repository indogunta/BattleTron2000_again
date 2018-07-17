using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISaving : MonoBehaviour
{
    [SerializeField]
    private Slider quality;
    [SerializeField]
    private Toggle fullScreen;
    [SerializeField]
    private Text res;
    bool bytes;

    private void Awake()
    {
        //quality.Set(PlayerPrefs.GetInt("Quality", 0));
        if (PlayerPrefs.HasKey("Quality"))
        {
            float tmp = PlayerPrefs.GetFloat("Quality");
            quality.value = tmp;    
          
        }
        if(PlayerPrefs.GetInt("FullScreen") == 1 && PlayerPrefs.HasKey("FullScreen"))
        {
            fullScreen.isOn = true;
        }
        else
        {
            fullScreen.isOn = false;
        }
       if(PlayerPrefs.HasKey("Quality"))
        {
            res.text = PlayerPrefs.GetString("Resolusion");
        }
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Quality", quality.value);
        PlayerPrefs.SetInt("FullScreen", Convert.ToInt32(fullScreen.isOn));
        PlayerPrefs.SetString("Resolusion", res.text);
        PlayerPrefs.Save();
        Convert.ToByte(bytes);
    }
   
}
