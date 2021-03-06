﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class CubesTypes : MonoBehaviour
{
    [Header("Common")]
    public CubesTypes Ct;
    public Movement Mv;

    [Header("Pillar")]
    public bool isStep = false;
    public Renderer rendy;

    [Header("Teleport")]
    public Transform player;
    public Vector3 pos;
    public bool isTeleport = false;
    public bool omniDirectional = false;
    public CubesTypes CtTelepot;


    [Header("End Cube")]
    public string levelName;
    public Animator endPanel;

    [Header("Score")]
    public Animator _nextLevel;
    public int ThreeStars;
    public int TwoStars;
    public int OneStar;

    [Header("Player Prefs")]
    public int currentStars = 0;
    public int levelIndex;

    [Header("Other")]
    private DepthOfField dof;
    public PostProcessVolume ppv;
    public GameObject Score;
    public ScoreEntrance Se;

    [Header("Audio Sources")]
    public AudioSource Effects_AS;
    public AudioManager_V2 BG_AS;

    [Header("Audio Clips")]
    public AudioClip Switches;
    public AudioClip Portals;
    public AudioClip Final;

    public Ad_Manager Ads;

    // Start is called before the first frame update
    void Start()
    {
        Ads = GameObject.Find("AdManager").GetComponent<Ad_Manager>();
        Ct = GetComponent<CubesTypes>();
        ppv.profile.TryGetSettings(out dof);
        rendy = GetComponent<Renderer>();
        Effects_AS = GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioSource>();
        BG_AS = GameObject.Find("Audio Manager").GetComponent<AudioManager_V2>();
        Portals = (AudioClip)Resources.Load("SoundEffects/PortalsTumble_The_Game");
        Switches = (AudioClip)Resources.Load("SoundEffects/Activate_SwitchTumble_The_Game");
        Final = (AudioClip)Resources.Load("SoundEffects/Level_ClearTumble");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (omniDirectional)
        {
            Debug.Log("Portal is Omni Directional");
        }
        else if(!omniDirectional)
        {
            if (other.gameObject.tag == "Player" && this.gameObject.tag == "Teleport")
            {
                if (!isTeleport)
                {
                    Ct.isTeleport = false;
                    Effects_AS.PlayOneShot(Portals, 0.4f);
                    StartCoroutine(Teleport());
                }
            }
            else if (other.gameObject.tag == "Player" && this.gameObject.tag == "Tutorial_Teleport")
            {
                if (!isTeleport)
                {
                    Ct.isTeleport = false;
                    StartCoroutine(Tutorial_Teleport());
                }
            }
            else if (other.gameObject.tag == "Player" && this.gameObject.tag == "Pillar")
            {
                Effects_AS.PlayOneShot(Switches, 0.3f);
                isStep = true;
                GetComponent<Renderer>().material.color = new Color32(159, 159, 159, 255);
            }
            else if (other.gameObject.tag == "Player" && this.gameObject.tag == "End Cube")
            {
                Ads.HideBannerAd();
                StartCoroutine(NextLevelLoad());
                BG_AS.endFade();
                //AS.clip = Final;
                Effects_AS.PlayOneShot(Final, 0.2f);
                if (Mv._Moves <= ThreeStars)
                {
                    //_nextLevel.SetTrigger("3s");
                    Score.SetActive(true);
                    Se.Star3();
                    currentStars = 3;
                    PlayerPrefs.SetInt("Lv" + levelIndex, currentStars);
                }
                else if (Mv._Moves > ThreeStars && Mv._Moves <= TwoStars)
                {
                    //_nextLevel.SetTrigger("2s");
                    Score.SetActive(true);
                    Se.Star2();
                    currentStars = 2;
                    PlayerPrefs.SetInt("Lv" + levelIndex, currentStars);
                }
                else if (Mv._Moves > TwoStars && Mv._Moves <= OneStar)
                {
                    //_nextLevel.SetTrigger("1s");
                    Score.SetActive(true);
                    Se.Star1();
                    currentStars = 1;
                    PlayerPrefs.SetInt("Lv" + levelIndex, currentStars);
                }
            }
        }

        Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, currentStars));
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Teleport" || other.gameObject.tag == "Player" && this.gameObject.tag == "Tutorial_Teleport")
        {
            isTeleport = !isTeleport;
        }
    }

    IEnumerator Teleport()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = false;
        player.transform.DOScale(0f, 0.3f);
        yield return new WaitForSeconds(0.5f);
        player.transform.position = pos;
        player.transform.DOScale(2, 0.3f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = true;
    }

    IEnumerator Tutorial_Teleport()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<TutorialMovement>().enabled = false;
        player.transform.DOScale(0f, 0.3f);
        yield return new WaitForSeconds(0.5f);
        player.transform.position = pos;
        player.transform.DOScale(2, 0.3f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TutorialMovement>().enabled = true;
    }

    IEnumerator NextLevelLoad()
    {
        yield return new WaitForSeconds(.1f);
        Mv.enabled = false;
        yield return new WaitForSeconds(1.1f);
        endPanel.SetTrigger("Start");
        ppv.profile.TryGetSettings(out dof);
        dof.enabled.value = enabled;
    }
}