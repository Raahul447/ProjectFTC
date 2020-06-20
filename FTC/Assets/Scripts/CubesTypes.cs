﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;
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
    public CubesTypes CtTelepot;


    [Header("End Cube")]
    public string levelName;
    public Animator endPanel;


    // Start is called before the first frame update
    void Start()
    {
        Ct = GetComponent<CubesTypes>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player" && this.gameObject.tag == "Teleport")
        {
            if (!isTeleport)
            {
                Ct.isTeleport = false;
                StartCoroutine(Teleport());
            }
        }
        else if(other.gameObject.tag == "Player" && this.gameObject.tag == "Pillar")
        {
            isStep = true;
        }
        else if (other.gameObject.tag == "Player" && this.gameObject.tag == "End Cube")
        {
            StartCoroutine(NextLevelLoad());
        }
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
        player.transform.DOScale(0f, 0.3f);
        yield return new WaitForSeconds(0.5f);
        player.transform.position = pos;
        player.transform.DOScale(2, 0.3f);
    }

    IEnumerator NextLevelLoad()
    {
        yield return new WaitForSeconds(1f);
        endPanel.SetTrigger("Start");
        Mv.enabled = false;
    }
}