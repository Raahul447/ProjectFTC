using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public PostProcessVolume ppv;
    private DepthOfField dof;
    public GameObject _PauseMenu;
    public bool _isTMove;
    public bool _isMove;

    // Start is called before the first frame update
    void Start()
    {
        ppv.profile.TryGetSettings(out dof);
        _PauseMenu = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _Resume()
    {
        _PauseMenu.SetActive(false);
        ppv.profile.TryGetSettings(out dof);
        Time.timeScale = 1;
        dof.enabled.value = !enabled;
        if (_isTMove)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<TutorialMovement>().enabled = true;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = true;
        }
    }

    public void _MM()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main_Menu");
    }

    public void _Retry()
    {
        Time.timeScale = 1;
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    public void _Pause()
    {
        ppv.profile.TryGetSettings(out dof);
        dof.enabled.value = enabled;
        Time.timeScale = 0;
        if (_isTMove)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<TutorialMovement>().enabled = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = false;
        }
    }
}
