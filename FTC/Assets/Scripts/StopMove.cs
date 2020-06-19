using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StopMove : MonoBehaviour
{
    public TutorialMovement TM;
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stopmove()
    {
        TM.enabled = false;
    }

    public void startmove()
    {
        TM.enabled = true;
    }

    public void levelchange()
    {
        SceneManager.LoadScene(levelName);
    }
}
