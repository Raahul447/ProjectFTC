using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Camera_Pan : MonoBehaviour
{
    public GameObject Camera;
    public float time;
    public float yPos;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Camera.transform.DOLocalMoveY(yPos, time);
        }
    }
}
