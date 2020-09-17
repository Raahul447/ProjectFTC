using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class HeartsSystem : MonoBehaviour
{
    [Header("Hearts 1")]
    public Image Heart1;
    public Image Heart1Min;

    [Header("Hearts 2")]
    public Image Heart2;
    public Image Heart2Min;

    [Header("Hearts 3")]
    public Image Heart3;
    public Image Heart3Min;

    public HeartsSystem Hs;
    public GameObject player;
    public float timer;

    [Header("Hearts GameObjects")]
    public GameObject H1;
    public GameObject H2;
    public GameObject H3;

    private LifeSystem Ls;

    private void OnEnable()
    {
        player = GameObject.Find("Player");
        Ls = GameObject.Find("Life System").GetComponent<LifeSystem>();
        if (player)
        {
            StartCoroutine(Hearts());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Hearts_Start());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TwoLivesRemove()
    {
        Heart3Min.DOFade(0, 1);
        
    }

    public void OneLivesRemove()
    {
        Heart3Min.DOFade(0, 1);
        Heart2Min.DOFade(0, 1);
       
    }

    public void ZeroLivesRemove()
    {
        Heart3Min.DOFade(0, 1);
        Heart2Min.DOFade(0, 1);
        Heart1Min.DOFade(0, 1);
        
    }

    public void OneAdd()
    {
        Heart1Min.DOFade(1, 1);
    }

    public void TwoAdd()
    {
        Heart2Min.DOFade(1, 1);
        Heart1Min.DOFade(1, 1);
    }

    public void ThreeAdd()
    {
        Heart3Min.DOFade(1, 1);
        Heart2Min.DOFade(1, 1);
        Heart1Min.DOFade(1, 1);
    }

    //IEnumerator SwitchOn()
    //{
    //    yield return new WaitForSeconds(1);
    //    this.gameObject.SetActive(false);
    //}

    IEnumerator Hearts()
    {
        yield return new WaitForSeconds(0.1f); 
        if(Ls.lives == 3)
        {
            Heart1Min.DOFade(1, 1);
            Heart2Min.DOFade(1, 1);
            Heart3Min.DOFade(1, 1);
        }
        else if (Ls.lives == 2)
        {
            Heart1Min.DOFade(1, 1);
            Heart2Min.DOFade(1, 1);
        }
        else if (Ls.lives == 1)
        {
            Heart1Min.DOFade(1, 1);
        }
    }


    IEnumerator Hearts_Start()
    {
        yield return new WaitForSeconds(timer);
        H1.transform.DOLocalMoveY(-0.4f, 1);
        H2.transform.DOLocalMoveY(-0.4f, 1);
        H3.transform.DOLocalMoveY(-0.4f, 1);
        if (Ls.lives == 3)
        {
            Heart1Min.DOFade(1, 1);
            Heart2Min.DOFade(1, 1);
            Heart3Min.DOFade(1, 1);
        }
        else if (Ls.lives == 2)
        {
            Heart1Min.DOFade(1, 1);
            Heart2Min.DOFade(1, 1);
            Heart3Min.DOFade(0, 1);
        }
        else if (Ls.lives == 1)
        {
            Heart1Min.DOFade(1, 1);
            Heart2Min.DOFade(0, 1);
            Heart3Min.DOFade(0, 1);
        }
    }
}
