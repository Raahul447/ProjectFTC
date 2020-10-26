using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public RectTransform Menu, LevelSelect, Settings;
    public Image fadeImageLeft, fadeImageRight;
    public TextMeshProUGUI Loading;

    // Start is called before the first frame update
    void Start()
    {
        //Menu.DOAnchorPos(new Vector2(0, 334.9f), 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void RestartLevel()
    {
        //Scene loadedLevel = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(loadedLevel.buildIndex);
        StartCoroutine(FadeRetry());
    }

    public void ReturntoMenu()
    {
        StartCoroutine(FadeNextLevel());
        //SceneManager.LoadScene("Main_Menu_V2");
    }

    public void GTMain()
    {
        Menu.DOAnchorPos(new Vector2(0, 194), 0.25f);
    }

    public void GTLevelSelect()
    {
        LevelSelect.DOAnchorPos(new Vector2(0, 194), 0.25f).SetDelay(0.25f);
        Menu.DOAnchorPos(new Vector2(0, 2000), 0.25f);
    }

    public void CloseLevelSelect()
    {
        LevelSelect.DOAnchorPos(new Vector2(2000, 194), 0.25f);
        Menu.DOAnchorPos(new Vector2(0, 194), 0.25f);
    }

    public void GTSettings()
    {
        Settings.DOAnchorPos(new Vector2(0, 194), 0.25f).SetDelay(0.25f);
        Menu.DOAnchorPos(new Vector2(0, 2000), 0.25f);
    }

    public void CloseSettings()
    {
        Settings.DOAnchorPos(new Vector2(-2000, 194), 0.25f);
        Menu.DOAnchorPos(new Vector2(0, 194), 0.25f);
    }

    IEnumerator FadeNextLevel()
    {
        yield return new WaitForSeconds(0.3f);
        fadeImageLeft.transform.DOLocalMoveX(-278, 1f);
        fadeImageRight.transform.DOLocalMoveX(278, 1f);
        yield return new WaitForSeconds(0.5f);
        Loading.DOFade(1, 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Main_Menu_V2");
    }

    IEnumerator FadeRetry()
    {
        yield return new WaitForSeconds(0.3f);
        fadeImageLeft.transform.DOLocalMoveX(-278, 1f);
        fadeImageRight.transform.DOLocalMoveX(278, 1f);
        yield return new WaitForSeconds(0.5f);
        Loading.DOFade(1, 1);
        yield return new WaitForSeconds(1);
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }
}
