using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    public GameObject Cubes;
    public GameObject PillarObj;
    public GameObject PillarMain;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Cubes.SetActive(true);
    }

    public void StartPillar()
    {
        PillarObj.SetActive(true);
        PillarMain.SetActive(true);
        PillarMain.transform.DOLocalMoveY(4.78f, 2.5f);
    }
}
