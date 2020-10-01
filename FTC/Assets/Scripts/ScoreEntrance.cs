using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEntrance : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject LTop;
    public GameObject LBottom;
    public GameObject LC;
    public GameObject Stars;

    [Header("Icon Gameobjects")]
    public GameObject HomeObj;
    public GameObject RestartObj;
    public GameObject NextObj;

    [Header("Images")]
    public Image Bg;
    public Image TopImage;
    public Image BotImage;

    [Header("Icons")]
    public Image Home;
    public Image Restart;
    public Image Next;

    [Header("Scripts")]
    [SerializeField]
    private GameObject Ls;

    [Header("Stars Complete")]
    public GameObject StarComp1;
    public GameObject StarComp2;
    public GameObject StarComp3;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartLevel1());
        //Ls = GameObject.FindGameObjectWithTag("LifeSystem");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartLevel1()
    {
        yield return new WaitForSeconds(1.5f);
        Bg.DOFade(0.5f, 0.5f);
        yield return new WaitForSeconds(1);
        TopImage.DOFade(1, 1);
        BotImage.DOFade(1, 1);
        yield return new WaitForSeconds(0.3f);
        LTop.transform.DOLocalMoveY(340, 1.2f);
        LBottom.transform.DOLocalMoveY(-287, 1.2f);
        yield return new WaitForSeconds(0.5f);
        LC.transform.DOLocalMoveY(215, 1.5f);
        yield return new WaitForSeconds(0.4f);
        LC.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        Stars.transform.DOLocalMoveY(0, 1);
        yield return new WaitForSeconds(0.4f);
        Stars.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Home.DOFade(1, 1);
        Restart.DOFade(1, 1);
        Next.DOFade(1, 1);
        StarComp1.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f);
    }


    IEnumerator StartLevel2()
    {
        yield return new WaitForSeconds(1.5f);
        Bg.DOFade(0.5f, 0.5f);
        yield return new WaitForSeconds(1);
        TopImage.DOFade(1, 1);
        BotImage.DOFade(1, 1);
        yield return new WaitForSeconds(0.3f);
        LTop.transform.DOLocalMoveY(340, 1.2f);
        LBottom.transform.DOLocalMoveY(-287, 1.2f);
        yield return new WaitForSeconds(0.5f);
        LC.transform.DOLocalMoveY(215, 1.5f);
        yield return new WaitForSeconds(0.4f);
        LC.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        Stars.transform.DOLocalMoveY(0, 1);
        yield return new WaitForSeconds(0.4f);
        Stars.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Home.DOFade(1, 1);
        Restart.DOFade(1, 1);
        Next.DOFade(1, 1);
        StarComp1.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f);
        StarComp2.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f);
    }


    IEnumerator StartLevel3()
    {
        yield return new WaitForSeconds(1.5f);
        Bg.DOFade(0.5f, 0.5f);
        yield return new WaitForSeconds(1f);
        TopImage.DOFade(1, 1);
        BotImage.DOFade(1, 1);
        yield return new WaitForSeconds(0.3f);
        LTop.transform.DOLocalMoveY(340, 1.2f);
        LBottom.transform.DOLocalMoveY(-287, 1.2f);
        yield return new WaitForSeconds(0.5f);
        LC.transform.DOLocalMoveY(215, 1.5f);
        yield return new WaitForSeconds(0.4f);
        LC.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        Stars.transform.DOLocalMoveY(0, 1);
        yield return new WaitForSeconds(0.4f);
        Stars.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Home.DOFade(1, 1);
        Restart.DOFade(1, 1);
        Next.DOFade(1, 1);
        StarComp1.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f);
        StarComp2.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f);
        StarComp3.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("Main_Menu_V2");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Star1()
    {
        StartCoroutine(StartLevel1());
    }

    public void Star2()
    {
        StartCoroutine(StartLevel2());
    }

    public void Star3()
    {
        StartCoroutine(StartLevel3());
    }
}
