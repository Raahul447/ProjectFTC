using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class LevelSelection_Final : MonoBehaviour
{
    public bool unlocked;
    public GameObject unlockedImage;
    public GameObject[] stars;

    public Sprite starsImage;

    [Header("Fade Images")]
    public Image fadeImageLeft;
    public Image fadeImageRight;

    [Header("Loading")]
    public TextMeshProUGUI Loading;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

    private void UpdateLevelImage()
    {
        if (!unlocked) //Level is Locked
        {
            unlockedImage.SetActive(true);
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else //Level is Unlocked
        {
            unlockedImage.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }

            for(int i = 0; i < PlayerPrefs.GetInt("Lv" + gameObject.name); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starsImage;
            }
        }
    }

    private void UpdateLevelStatus()
    {
        int previousLevelNum = int.Parse(gameObject.name) - 1;
        if(PlayerPrefs.GetInt("Lv" + previousLevelNum) > 0)
        {
            unlocked = true;
        }
    }

    public void selectLevel(string levelName)
    {
        if (unlocked)
        {
            StartCoroutine(FadeStart(levelName));
        }
    }

    IEnumerator FadeStart(string levelName)
    {
        yield return new WaitForSeconds(.3f);
        fadeImageLeft.transform.DOLocalMoveX(-120.69f, 1f);
        fadeImageRight.transform.DOLocalMoveX(120.69f, 1f);
        yield return new WaitForSeconds(0.5f);
        Loading.DOFade(1, 1);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);
    }
}
