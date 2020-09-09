using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Cam_DoTween : MonoBehaviour
{
    [Header("Cam")]
    public GameObject Camera;
    public float x_Norm;
    public float y_Norm;
    public float z_Norm;

    [Header("Values")]
    public float y_Cam;
    public float time;

    [Header("Rotate Values")]
    public float x_Rot;
    public float y_Rot;
    public float z_Rot;

    [Header("Booleans")]
    public bool isSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        Camera.transform.position = new Vector3(transform.position.x, 35, transform.position.z);
        StartCoroutine(CamMove());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Cam_Switch()
    {
        isSwitch = !isSwitch;

        if (isSwitch)
        {
            Camera.transform.DORotate(new Vector3(90, 0, 0), 1);
            Camera.transform.DOLocalMove(new Vector3(x_Rot, y_Rot, z_Rot), 1);
        }
        else
        {
            Camera.transform.DORotate(new Vector3(35.264f, -45, 0), 1);
            Camera.transform.DOLocalMove(new Vector3(x_Norm, y_Norm, z_Norm), 1);
        }
    }

    IEnumerator CamMove()
    {
        Camera.transform.DOLocalMoveY(35, 1);
        yield return new WaitForSeconds(0.7f);
        Camera.transform.DOLocalMoveY(y_Cam, time);
    }
}
