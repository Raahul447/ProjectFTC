using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            //First launch
            PlayerPrefs.SetInt("Tutorial", 1);
            SceneManager.LoadScene("New_Tutorial");
        }
        else
        {
            //Load scene_02 if its not the first launch
            SceneManager.LoadScene("Main_Menu_V2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
