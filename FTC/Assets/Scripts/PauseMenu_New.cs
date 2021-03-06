﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class PauseMenu_New : MonoBehaviour
{
    public GameObject PauseMask;
    public GameObject ExitObj;
    public GameObject RetryObj;
    public bool isPaused = false;
    [SerializeField]
    private GameObject lifeSystem;

    [Header("PPE")]
    public PostProcessVolume ppv;
    private ColorGrading Cg;
    private DepthOfField dof;

    [Header("Fade Images")]
    public Image fadeImageLeft;
    public Image fadeImageRight;

    [Header("Loading Text")]
    public TextMeshProUGUI loadingText;

    [Header("Ads")]
    //public Ad_Manager Ad;

    public AudioSource Click;

    public bool isMute = false;

    public Image audioLogo;
    public int volume;
    public AudioManager_V2 Am;

    public Movement mv;
    public LifeSystem Ls;
    public GameObject refill;

    // Start is called before the first frame update
    void Start()
    {
        lifeSystem = GameObject.FindGameObjectWithTag("LifeSystem");
        Ls = GameObject.FindGameObjectWithTag("LifeSystem").GetComponent<LifeSystem>();
        ppv.profile.TryGetSettings(out Cg);
        ppv.profile.TryGetSettings(out dof);
        Click = this.gameObject.GetComponent<AudioSource>();
        Am = GameObject.Find("Audio Manager").GetComponent<AudioManager_V2>();
        mv = GameObject.Find("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    ExitObj.SetActive(true);
        //    ExitObj.transform.DOLocalMoveY(10, 0.5f);
        //}

        if(AudioListener.volume == 0)
        {
            audioLogo.sprite = Resources.Load<Sprite>("Images/Mute");
        }
        else
        {
            audioLogo.sprite = Resources.Load<Sprite>("Images/UnMute");
        }
    }

    public void Mute()
    {
        isMute = !isMute;
        if (isMute)
        {
            PlayerPrefs.SetInt("volume", 0);
            AudioListener.volume = 0;
        }
        else
        {
            PlayerPrefs.SetInt("volume", 1);
            AudioListener.volume = 1;

        }
        //adButton();
    }

    public void Pause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            PauseMask.transform.DOLocalMoveY(-100, 0.4f);
            Click.Play();
            //Ad.PlayBannerAd();
            //mv.enabled = false;
        }
        else
        {
            Click.Play();
            PauseMask.transform.DOLocalMoveY(2, 0.4f);
            //Ad.HideBannerAd();
            //mv.enabled = true;
        }
    }

    public void Exit()
    {
        //Click.Play();
        ExitObj.SetActive(true);
        ExitObj.transform.DOLocalMoveY(10, 0.5f);
        mv.enabled = false;
    }

    public void NoButton()
    {
        //Click.Play();
        PauseMask.transform.DOLocalMoveY(2, 0.4f);
        ExitObj.transform.DOLocalMoveY(-38, 0.5f);
        isPaused = false;
        //Ad.HideBannerAd();
        ExitObj.SetActive(false);
        mv.enabled = true;
    }

    public void YesButton()
    {
        Am.Main.DOFade(0, 1);
        Click.Play();
        //Ad.HideBannerAd();
        StartCoroutine(FadeStart());
    }

    public void adButton()
    {
        //Ad.isMute = true;
    }

    public void Retry()
    {
        //Click.Play();
        //Ad.HideBannerAd();
        Am.Main.DOFade(0, 1);
        if (Ls.currentLives == 1)
        {
            lifeSystem.GetComponent<LifeSystem>().lives--;
            refill.SetActive(true);
            return;
        }
        else
        {
            Scene loadedLevel = SceneManager.GetActiveScene();
            SceneManager.LoadScene(loadedLevel.buildIndex);
            if (lifeSystem.GetComponent<LifeSystem>().lives != 0)
            {
                lifeSystem.GetComponent<LifeSystem>().lives--;
                return;
            }
        }
    }

    public void RetryButton()
    {
        //Click.Play();
        RetryObj.SetActive(true);
        RetryObj.transform.DOLocalMoveY(10, 0.5f);
        Cg.saturation.value = -100;
        //Ad.HideBannerAd();
        mv.enabled = false;
    }

    public void RetryNo()
    {
        //Click.Play();
        PauseMask.transform.DOLocalMoveY(2, 0.4f);
        RetryObj.transform.DOLocalMoveY(-38, 0.5f);
        RetryObj.SetActive(false);
        Cg.saturation.value = 0;
        isPaused = false;
        //Ad.HideBannerAd();
        mv.enabled = true;
    }

    IEnumerator FadeStart()
    {
        yield return new WaitForSeconds(0.3f);
        fadeImageLeft.transform.DOLocalMoveX(-126f, 1f);
        fadeImageRight.transform.DOLocalMoveX(126f, 1f);
        yield return new WaitForSeconds(0.3f);
        loadingText.DOFade(1,1);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main_Menu_V2");
        if (lifeSystem.GetComponent<LifeSystem>().lives != 0)
        {
            lifeSystem.GetComponent<LifeSystem>().lives--;
        }
    }
}
