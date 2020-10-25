using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Title_Trailer : MonoBehaviour
{

    public GameObject Camera;
    public GameObject Cubes;
    public GameObject Logo;
    public TextMeshProUGUI LogoOther;
    public GameObject diamond;

    public Image BG;
    public TextMeshProUGUI outnow;
    public Image playstore;
    public TextMeshProUGUI copyright;
    public Image fade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(OutNow());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        Cubes.SetActive(true);
        yield return new WaitForSeconds(1);
        Camera.transform.DOLocalMoveY(50, 3.5f);
        diamond.SetActive(true);
        yield return new WaitForSeconds(1);
        Logo.transform.DOLocalMove(new Vector3(-441.5f, -200.5f, 6.5f), 1.5f);
        yield return new WaitForSeconds(0.5f);
        LogoOther.DOFade(1, 0.1f);
        //yield return new WaitForSeconds(1.4f);
        
    }

    IEnumerator OutNow()
    {
        yield return new WaitForSeconds(0.2f);
        BG.DOFade(1, 1);
        yield return new WaitForSeconds(0.2f);
        outnow.DOFade(1, 1);
        yield return new WaitForSeconds(0.2f);
        playstore.DOFade(1, 1);
        copyright.DOFade(1, 1.5F);
        yield return new WaitForSeconds(5);
        fade.DOFade(1, 1);
    }
}
