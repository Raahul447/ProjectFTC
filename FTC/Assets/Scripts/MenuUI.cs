using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
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

    [Header("Lvl_Select")]
    public GameObject Desert;
    public GameObject Mountain;
    public GameObject Ice;
    public GameObject Lava;

    // Bools
    public bool isLS = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartUI());
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
            Underline.DOAnchorPos(new Vector2(-144.5f, -333.8f), 0.5f);

            //Play_BG.DOFade(1, 1);
            //LS_BG.DOFade(0, 1);
            //Settings_BG.DOFade(0, 1);
            //Credits_BG.DOFade(0, 1);
        }
    }

    IEnumerator StartUI()
    {
        LineObj.DOFade(1, 3);
        LineObject.DOScaleX(0.9998868f, 2);
        yield return new WaitForSeconds(0.8f);
        TumbleText.DOAnchorPos(new Vector2(-10.3f, -35), 1f);
        yield return new WaitForSeconds(1);
        PlayText.DOAnchorPos(new Vector2(-10.3f, -35), 0.5f);
        yield return new WaitForSeconds(0.5f);
        BottomTab.DOAnchorPos(new Vector2(0, 61), 0.5f);
        Underline.DOAnchorPos(new Vector2(-144.5f, -333.8f), 0.5f);
    }

    public void Credits()
    {
        PlayObj.DOAnchorPos(new Vector2(-549, 0), 1f);
        CreditsObj.DOAnchorPos(new Vector2(0, 0), 1f);
        SettingsObj.DOAnchorPos(new Vector2(549, 0), 1f);
        Underline.DOAnchorPos(new Vector2(60, -333.8f), 0.5f);

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
        Underline.DOAnchorPos(new Vector2(157, -333.8f), 0.5f);

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
        Underline.DOAnchorPosY(-467, 0.5f);

        Desert.transform.DOScale(new Vector3(1, 1, 1), 1);
        Mountain.transform.DOScale(new Vector3(1, 1, 1), 1);
        Ice.transform.DOScale(new Vector3(1, 1, 1), 1);
        Lava.transform.DOScale(new Vector3(1, 1, 1), 1);
        //LS_BG.DOFade(1, 1);
        //Settings_BG.DOFade(0, 1);
        //Credits_BG.DOFade(0, 1);
        //Play_BG.DOFade(0, 1);

        isLS = true;
    }

    public void Play()
    {
        PlayText.DOAnchorPos(new Vector2(-10.3f, -35), 0.5f);
        PlayObj.DOAnchorPos(new Vector2(0, 0), 1f);
        LSObj.DOAnchorPos(new Vector2(549, 0), 1f);
        SettingsObj.DOAnchorPos(new Vector2(2196, 0), 1f);
        CreditsObj.DOAnchorPos(new Vector2(1098, 0), 1f);
        Underline.DOAnchorPos(new Vector2(-144.5f, -333.8f), 0.5f);

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
        Underline.DOAnchorPos(new Vector2(-144.5f, -333.8f), 0.5f);
        PlayObj.DOAnchorPos(new Vector2(0, 0), 1);
        LSObj.DOAnchorPos(new Vector2(549, 0), 1);
        CreditsObj.DOAnchorPos(new Vector2(1098, 0), 1f);
        SettingsObj.DOAnchorPos(new Vector2(2196, 0), 1f);

        Desert.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Mountain.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Ice.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Lava.transform.DOScale(new Vector3(0, 0, 0), 0.5f);

        //Play_BG.DOFade(1, 1);
        //LS_BG.DOFade(0, 1);
        //Settings_BG.DOFade(0, 1);
        //Credits_BG.DOFade(0, 1);
    }
}
