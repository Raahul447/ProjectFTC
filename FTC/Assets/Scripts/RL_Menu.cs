using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RL_Menu : MonoBehaviour
{

    public Ad_Manager Am;
    public GameObject refill;

    // Start is called before the first frame update
    void Start()
    {
        Am = GameObject.Find("AdManager").GetComponent<Ad_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main_Menu_V2");
    }

    public void wait()
    {
        refill.SetActive(false);
    }

    public void Refill()
    {
        Am.PlayRewardedVideoAd();
    }
}
