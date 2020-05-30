using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{

    public bool isSwitch = false;
    public Animator ui;

    public GameObject playerCircle;
    public GameObject Pause, View, Highlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        isSwitch = !isSwitch; 
    }

    public void CircleEffect1()
    {
        playerCircle.transform.DOScale(1, 0.5f);
    }

    public void LoadinUI()
    {
        //Pause.transform.DOMoveY(2,2);
        //View.transform.DOMove(new Vector3(-134, -129, 0), 0);
    }

    IEnumerator Load_All()
    {
        LoadinUI();
        yield return new WaitForSeconds(0.3f);
        Highlight.SetActive(transform);
        CircleEffect1();
    }
}
