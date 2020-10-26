using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    // UI GameObjects
    [Header("UI GameObjects")]
    public Image LineObj;
    public Image Arrow;

    // Other Rects
    [Header("Other Rects")]
    public RectTransform TumbleText;
    public RectTransform PlayText;
    public RectTransform BottomTab;

    // Other Main
    [Header("Main Rects")]
    public RectTransform PlayObj;
    public RectTransform CreditsObj;
    public RectTransform SettingsObj;
    public RectTransform ArrowObj;
    public RectTransform LevelSelectObj;
    public RectTransform LSObj;
    public RectTransform Underline;
    public RectTransform LineObject;

    // Backgrounds
    [Header("Backgrounds")]
    public Image Play_BG;
    public Image LS_BG;
    public Image Credits_BG;
    public Image Settings_BG;
    public Image UnderlineColor;

    [Header("Lvl_Select")]
    public GameObject Desert;
    public GameObject Mountain;
    public GameObject Ice;
    public GameObject Lava;

    [Header("Sub Menus")]
    public GameObject DSub;
    public GameObject MSub;
    public GameObject SSub;
    public GameObject LSub;

    [Header("BG")]
    public GameObject Main;
    public Material D;
    public Material M;
    public Material S;
    public Material L;

    public TextMeshProUGUI LvlSlct;
    public GameObject PlayB;

    // Bools
    public bool isLS = false;
    public int recentLevel;

    [Header("Fade Images")]
    public Image fadeImageLeft;
    public Image fadeImageRight;

    [Header("Loading")]
    public TextMeshProUGUI Loading;

    [Header("Hearts")]
    public RectTransform Hearts;
    public LifeSystem LifeSystem;

    [Header("Audio")]
    public AudioManager_V2 Am;
    public int volume;
    public GameObject Red;
    public GameObject Green;


    //public Ad_Manager ad;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("volume", 1);
        volume = PlayerPrefs.GetInt("volume", 0);
        StartCoroutine(StartUI());
        recentLevel = PlayerPrefs.GetInt("levelAt", 3);
        LifeSystem = GameObject.Find("Life System").GetComponent<LifeSystem>();
        Am = GameObject.Find("Audio Manager").GetComponent<AudioManager_V2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isLS)
        {
            Arrow.DOFade(0, 0.5f);
            ArrowObj.DOAnchorPos(new Vector2(38, 272), 1f);
            TumbleText.DOAnchorPos(new Vector2(-10.3f, -35), 1f);
            PlayText.DOAnchorPos(new Vector2(-10.3f, -35), 0.5f);
            LevelSelectObj.DOAnchorPos(new Vector2(-1.5f, 35), 1);
            BottomTab.DOAnchorPos(new Vector2(0, 61), 0.5f);
            Underline.DOAnchorPos(new Vector2(-144.5f, 70f), 0.5f);

            //Play_BG.DOFade(1, 1);
            //LS_BG.DOFade(0, 1);
            //Settings_BG.DOFade(0, 1);
            //Credits_BG.DOFade(0, 1);
        }

        if(volume == 0)
        {

        }
        else if(volume == 1)
        {

        }
    }

    IEnumerator StartUI()
    {
        LineObj.DOFade(1, 3);
        LineObject.DOScaleX(0.9998868f, 2);
        yield return new WaitForSeconds(0.8f);
        TumbleText.DOAnchorPos(new Vector2(-10.3f, -35), 1f);
        Hearts.DOAnchorPos(new Vector2(-54.60001f, -27.60001f),1);
        yield return new WaitForSeconds(1);
        PlayText.DOAnchorPos(new Vector2(-10.3f, -35), 0.5f);
        yield return new WaitForSeconds(0.5f);
        BottomTab.DOAnchorPos(new Vector2(0, 61), 0.5f);
        Underline.DOAnchorPos(new Vector2(-144.5f, 70f), 0.5f);
        UnderlineColor.color = new Color32(255, 121, 140, 255);
        PlayB.transform.DOLocalMoveY(0, 1);
        yield return new WaitForSeconds(0.2f);
        PlayB.SetActive(true);
    }

    public void Credits()
    {
        PlayObj.DOAnchorPos(new Vector2(-549, 0), 1f);
        CreditsObj.DOAnchorPos(new Vector2(0, 0), 1f);
        SettingsObj.DOAnchorPos(new Vector2(549, 0), 1f);
        Underline.DOAnchorPos(new Vector2(60, 70f), 0.5f);
        UnderlineColor.color = new Color32(255, 182, 114, 255);
        //PlayB.SetActive(false);
        //Credits_BG.DOFade(1, 1);
        //Play_BG.DOFade(0, 1);
        //LS_BG.DOFade(0, 1);
        //Settings_BG.DOFade(0, 1);
    }

    public void Settings()
    {

        PlayObj.DOAnchorPos(new Vector2(-1098, 0), 1f);
        SettingsObj.DOAnchorPos(new Vector2(0, 0), 1f);
        CreditsObj.DOAnchorPos(new Vector2(-549, 0), 1f);
        Underline.DOAnchorPos(new Vector2(157, 70f), 0.5f);
        UnderlineColor.color = new Color32(128, 255, 166, 255);
        //PlayB.SetActive(false);
        //Settings_BG.DOFade(1, 1);
        //Credits_BG.DOFade(0, 1);
        //Play_BG.DOFade(0, 1);
        //LS_BG.DOFade(0, 1);
    }

    public void LevelSelect()
    {
        Arrow.DOFade(1, 0.5f);
        TumbleText.DOAnchorPos(new Vector2(-10.3f, -105f), 1f);
        ArrowObj.DOAnchorPos(new Vector2(-130, 293), 1f);
        CreditsObj.DOAnchorPos(new Vector2(549, 0), 1f);
        SettingsObj.DOAnchorPos(new Vector2(1098, 0), 1f);
        PlayText.DOAnchorPos(new Vector2(-10.3f, 29.3f), 0.5f);
        LevelSelectObj.DOAnchorPos(new Vector2(1.5f, -43), 1);
        LSObj.DOAnchorPos(new Vector2(0, 0), 1);
        BottomTab.DOAnchorPos(new Vector2(0, -36.1f), 0.5f);
        Underline.DOAnchorPosY(-38f, 0.5f);

        Desert.transform.DOScale(new Vector3(1, 1, 1), 1);
        Mountain.transform.DOScale(new Vector3(1, 1, 1), 1);
        Ice.transform.DOScale(new Vector3(1, 1, 1), 1);
        Lava.transform.DOScale(new Vector3(1, 1, 1), 1);
        //LS_BG.DOFade(1, 1);
        //Settings_BG.DOFade(0, 1);
        //Credits_BG.DOFade(0, 1);
        //Play_BG.DOFade(0, 1);

        isLS = true;
        PlayB.SetActive(false);
    }

    public void Play()
    {
        PlayText.DOAnchorPos(new Vector2(-10.3f, -35), 0.5f);
        PlayObj.DOAnchorPos(new Vector2(0, 0), 1f);
        LSObj.DOAnchorPos(new Vector2(549, 0), 1f);
        SettingsObj.DOAnchorPos(new Vector2(2196, 0), 1f);
        CreditsObj.DOAnchorPos(new Vector2(1098, 0), 1f);
        Underline.DOAnchorPos(new Vector2(-144.5f, 70f), 0.5f);
        UnderlineColor.color = new Color32(255, 121, 140, 255);
        PlayB.SetActive(true);
        //Play_BG.DOFade(1, 1);
        //LS_BG.DOFade(0, 1);
        //Settings_BG.DOFade(0, 1);
        //Credits_BG.DOFade(0, 1);
    }

    public void BackArrow()
    {
        Arrow.DOFade(0, 0.5f);
        ArrowObj.DOAnchorPos(new Vector2(38, 272), 1f);
        TumbleText.DOAnchorPos(new Vector2(-10.3f, -35), 1f);
        PlayText.DOAnchorPos(new Vector2(-10.3f, -35), 0.5f);
        LevelSelectObj.DOAnchorPos(new Vector2(-1.5f, 35), 1);
        BottomTab.DOAnchorPos(new Vector2(0, 61), 0.5f);
        Underline.DOAnchorPos(new Vector2(-144.5f, 70f), 0.5f);
        PlayObj.DOAnchorPos(new Vector2(0, 0), 1);
        LSObj.DOAnchorPos(new Vector2(549, 0), 1);
        CreditsObj.DOAnchorPos(new Vector2(1098, 0), 1f);
        SettingsObj.DOAnchorPos(new Vector2(2196, 0), 1f);
        UnderlineColor.color = new Color32(255, 121, 140, 255);
        Desert.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Mountain.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Ice.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Lava.transform.DOScale(new Vector3(0, 0, 0), 0.5f);

        StartCoroutine(loadplay());
        //Play_BG.DOFade(1, 1);
        //LS_BG.DOFade(0, 1);
        //Settings_BG.DOFade(0, 1);
        //Credits_BG.DOFade(0, 1);
    }

    public void DesertSub()
    {
        StartCoroutine(DS());
        Main.GetComponent<Renderer>().material = D; 
    }

    IEnumerator loadplay()
    {
        yield return new WaitForSeconds(0.5f);
        PlayB.SetActive(true);
    }

    IEnumerator DS()
    {
        Desert.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Mountain.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Ice.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Lava.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        yield return new WaitForSeconds(0.3f);
        Desert.SetActive(false);
        DSub.SetActive(true);
    }

    public void MtnSub()
    {
        StartCoroutine(MS());
        Main.GetComponent<Renderer>().material = M;
    }

    IEnumerator MS()
    {
        Desert.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Mountain.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Ice.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Lava.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        yield return new WaitForSeconds(0.3f);
        Mountain.SetActive(false);
        MSub.SetActive(true);
    }

    public void SnowSub()
    {
        StartCoroutine(SS());
        Main.GetComponent<Renderer>().material = S;
    }

    public void Mute()
    {
        AudioListener.volume = 0f;
        PlayerPrefs.SetInt("volume", 0);
        //ad.isMute = true;
    }

    public void unMute()
    {
        AudioListener.volume = 1f;
        PlayerPrefs.SetInt("volume", 1);
        //ad.isMute = true;
    }

    IEnumerator SS()
    {
        Desert.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Mountain.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Ice.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Lava.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        yield return new WaitForSeconds(0.3f);
        Ice.SetActive(false);
        SSub.SetActive(true);
    }

    public void LavaSub()
    {
        StartCoroutine(LS());
        Main.GetComponent<Renderer>().material = L;
    }

    IEnumerator LS()
    {
        Desert.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Mountain.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Ice.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Lava.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        yield return new WaitForSeconds(0.3f);
        Lava.SetActive(false);
        LSub.SetActive(true);
    }

    public void playbutton()
    {
        if(LifeSystem.lives > 0)
        {
            StartCoroutine(FadeImage());
        }
    }

    IEnumerator FadeImage()
    {
        Am.Main.DOFade(0, 1);
        yield return new WaitForSeconds(.3f);
        fadeImageLeft.transform.DOLocalMoveX(-120.69f, 1f);
        fadeImageRight.transform.DOLocalMoveX(120.69f, 1f);
        yield return new WaitForSeconds(0.5f);
        Loading.DOFade(1, 1);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(recentLevel);
    }
}
