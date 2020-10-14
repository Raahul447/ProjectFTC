using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{

    [Header("Values")]
    public float timer;

    [Header("Part 1")]
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;

    [Header("Part 1.5")]
    public GameObject obj5;

    [Header("Part 2")]
    public GameObject obj6;
    public GameObject obj7;
    public GameObject obj8;
    public GameObject obj9;

    [Header("Audio")]
    public AudioSource sound;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Splash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Splash()
    {
        obj1.SetActive(true);
        yield return new WaitForSeconds(timer);
        obj2.SetActive(true);
        yield return new WaitForSeconds(timer);
        obj3.SetActive(true);
        yield return new WaitForSeconds(timer);
        obj4.SetActive(true);
        yield return new WaitForSeconds(timer);
        obj5.SetActive(true);
        yield return new WaitForSeconds(timer);
        obj6.SetActive(true);
        yield return new WaitForSeconds(timer);
        obj7.SetActive(true);
        yield return new WaitForSeconds(timer);
        obj8.SetActive(true);
        yield return new WaitForSeconds(timer);
        obj9.SetActive(true);
        yield return new WaitForSeconds(timer);
        obj1.SetActive(false);
        yield return new WaitForSeconds(timer);
        obj2.SetActive(false);
        yield return new WaitForSeconds(timer);
        obj3.SetActive(false);
        yield return new WaitForSeconds(timer);
        obj4.SetActive(false);
        yield return new WaitForSeconds(timer);
        obj6.SetActive(false);
        yield return new WaitForSeconds(timer);
        obj7.SetActive(false);
        yield return new WaitForSeconds(timer);
        obj8.SetActive(false);
        yield return new WaitForSeconds(timer);
        obj9.SetActive(false);
        yield return new WaitForSeconds(1f);
        obj5.transform.DOLocalMoveX(500, 0.5f);
        yield return new WaitForSeconds(0.4f);
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
}
