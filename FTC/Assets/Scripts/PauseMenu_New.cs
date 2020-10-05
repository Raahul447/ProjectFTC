using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        lifeSystem = GameObject.FindGameObjectWithTag("LifeSystem");
        ppv.profile.TryGetSettings(out Cg);
        ppv.profile.TryGetSettings(out dof);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            PauseMask.transform.DOLocalMoveY(-100, 0.4f);
        }
        else
        {
            PauseMask.transform.DOLocalMoveY(2, 0.4f);
        }
    }

    public void Exit()
    {
        ExitObj.SetActive(true);
        ExitObj.transform.DOLocalMoveY(10, 0.5f);
    }

    public void NoButton()
    {
        PauseMask.transform.DOLocalMoveY(2, 0.4f);
        ExitObj.transform.DOLocalMoveY(-38, 0.5f);
        isPaused = false;
        ExitObj.SetActive(false);
    }

    public void YesButton()
    {
        StartCoroutine(FadeStart());
    }

    public void Retry()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
        if (lifeSystem.GetComponent<LifeSystem>().lives != 0)
        {
            lifeSystem.GetComponent<LifeSystem>().lives--;
            return;
        }
    }

    public void RetryButton()
    {
        RetryObj.SetActive(true);
        RetryObj.transform.DOLocalMoveY(10, 0.5f);
        Cg.saturation.value = -100;
    }

    public void RetryNo()
    {
        PauseMask.transform.DOLocalMoveY(2, 0.4f);
        RetryObj.transform.DOLocalMoveY(-38, 0.5f);
        RetryObj.SetActive(false);
        Cg.saturation.value = 0;
        isPaused = false;
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
