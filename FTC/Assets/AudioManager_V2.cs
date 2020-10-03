using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine;

public class AudioManager_V2 : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("HI");
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
