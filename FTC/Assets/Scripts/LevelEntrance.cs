﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class LevelEntrance : MonoBehaviour
{
    public GameObject LTop;
    public GameObject LBottom;

    public Image Border;
    public GameObject Number;

    public Image Line;
    public GameObject Name;

    private Scene scene;
    public TextMeshProUGUI textName;

    public GameObject cubes;
    public Image ltop;
    public Image lbot;

    public string lName;
    public GameObject GameUI;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLevel());
        textName.text = lName;
        //Debug.Log(scene.buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(0.7f);
        LTop.transform.DOLocalMoveY(340, 1.2f);
        LBottom.transform.DOLocalMoveY(-287, 1.2f);
        yield return new WaitForSeconds(1);
        Border.DOFade(1, 1);
        Number.transform.DOLocalMoveY(-29.1f, 1);
        Line.DOFade(1, 1);
        Name.transform.DOLocalMoveY(18.59998f, 1);
        yield return new WaitForSeconds(2);
        Border.DOFade(0, 1);
        Number.transform.DOLocalMoveY(-139, 0.6f);
        Line.DOFade(0, 1);
        Name.transform.DOLocalMoveY(-87, 1);
        yield return new WaitForSeconds(0.3f);
        LTop.transform.DOLocalMoveY(32.00002f, 1.2f);
        LBottom.transform.DOLocalMoveY(-62, 1.2f);
        yield return new WaitForSeconds(1f);
        cubes.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        ltop.DOFade(0, 1);
        lbot.DOFade(0, 1);
        yield return new WaitForSeconds(0.3f);
        GameUI.SetActive(true);
    }
}
