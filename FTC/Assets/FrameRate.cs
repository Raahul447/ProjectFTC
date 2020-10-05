using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    private void Awake()
    {
        //var resolution = Screen.currentResolution;
        //var height = (int)(resolution.height * 0.65f);
        //var width = (int)(resolution.width * 0.65f);
        //Screen.SetResolution(height, width, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
