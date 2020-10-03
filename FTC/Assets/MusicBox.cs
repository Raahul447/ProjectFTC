using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MusicBox : MonoBehaviour
{
    public string mainMenuTheme;
    //public string set1Theme;

    public static MusicBox Instance = null;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        scene = SceneManager.GetActiveScene();
        Debug.Log(scene);
        if (scene.name == "Main_Menu_V2")
        {
            Audiomanager.audiomanager.Play(mainMenuTheme);
            //StartCoroutine(PlayMusic());
        }
        else if (scene.name == "Level_1_Test" || scene.name == "Level_2")
        {
            Audiomanager.audiomanager.Stop(mainMenuTheme);
            //Audiomanager.audiomanager.Play(set1Theme);
        }
        //Debug.Log(scene.name);
        //Debug.Log(mode);
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    Scene currentScene = SceneManager.GetActiveScene();
    //    if (currentScene.name == "Main_Menu_V2")
    //    {
    //        StartCoroutine(PlayMusic());
    //    }
    //    else if (currentScene.name == "Level_1_Test" || currentScene.name == "Level_2")
    //    {
    //        Audiomanager.audiomanager.Stop(mainMenuTheme);
    //        Audiomanager.audiomanager.Play(set1Theme);
    //    }
    //}



    //private IEnumerator PlayMusic()
    //{
    //    Audiomanager.audiomanager.Play(mainMenuTheme);
    //    yield return null;
    //}
}
