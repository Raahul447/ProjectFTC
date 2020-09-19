using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu_New : MonoBehaviour
{
    public GameObject PauseMask;
    public GameObject ExitObj;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        ExitObj.SetActive(false);
    }
}
