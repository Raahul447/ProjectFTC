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

    private DepthOfField dof;
    public PostProcessVolume ppv;

    // Start is called before the first frame update
    void Start()
    {
        Ct = GetComponent<CubesTypes>();
        ppv.profile.TryGetSettings(out dof);
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
                    StartCoroutine(Teleport());
                }
            }
            else if (other.gameObject.tag == "Player" && this.gameObject.tag == "Pillar")
            {
                isStep = true;
            }
            else if (other.gameObject.tag == "Player" && this.gameObject.tag == "End Cube")
            {
                StartCoroutine(NextLevelLoad());
                if (Mv._Moves <= ThreeStars)
                {
                    _nextLevel.SetTrigger("3s");
                    currentStars = 3;
                    PlayerPrefs.SetInt("Lv" + levelIndex, currentStars);
                }
                else if (Mv._Moves > ThreeStars && Mv._Moves <= TwoStars)
                {
                    _nextLevel.SetTrigger("2s");
                    currentStars = 2;
                    PlayerPrefs.SetInt("Lv" + levelIndex, currentStars);
                }
                else if (Mv._Moves > TwoStars)
                {
                    _nextLevel.SetTrigger("1s");
                    currentStars = 1;
                    PlayerPrefs.SetInt("Lv" + levelIndex, currentStars);
                }
            }
        }

        Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, currentStars));
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Teleport")
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

    IEnumerator NextLevelLoad()
    {
        yield return new WaitForSeconds(.1f);
        Mv.enabled = false;
        yield return new WaitForSeconds(.5f);
        endPanel.SetTrigger("Start");
        ppv.profile.TryGetSettings(out dof);
        dof.enabled.value = enabled;
    }
}