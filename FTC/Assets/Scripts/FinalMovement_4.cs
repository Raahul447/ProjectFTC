using System.Collections;
using MilkShake;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FinalMovement_4 : MonoBehaviour
{
    //Movement 
    public float lerpSpeed = 10f;
    float lerpTime = 1f;
    Quaternion newRotation;
    Quaternion oldRotation;

    //Swipe Controls
    private float swipeResistanceX = 70.0f;
    private float swipeResistanceY = 100.0f;
    Vector2 touchPos;

    public int count = 0;

    public Animator welcomeAnim;
    public bool isFront = false;
    public bool isBack = false;

    //[Header("Shake")]
    //public Shaker myShaker;
    //public ShakePreset CamShake;

    void Start()
    {
        newRotation = oldRotation = transform.rotation;
    }

    void Update()
    {

        //Shakes();

        // get input from user and update state if need be
        UpdateRotationState();
        // if the lerp time is less than one, lerp to the new rotation
        if (lerpTime < 1f)
        {
            lerpTime += Time.deltaTime * lerpSpeed;
            transform.rotation = Quaternion.Lerp(oldRotation, newRotation, lerpTime);
        }
    }

    void UpdateRotationState()
    {
        // Get the rotation, if any
        float x = 0f, z = 0f;
        //Up
        if ((Input.GetKeyDown(KeyCode.W) || SwipeManager.IsSwipingUpRight()) && isFront)
        {
            //print("Forward");
            x = 90f;
            transform.position += Vector3.left * 2;
            count += 1;
        }
        //Down
        else if ((Input.GetKeyDown(KeyCode.S) || SwipeManager.IsSwipingDownLeft()) && isBack)
        {
            //print("Back");
            x = -90f;
            transform.position += Vector3.right * 2;
        }

        // if rotation is nonzero, apply it
        if (x != 0f || z != 0f)
        {
            newRotation = Quaternion.Euler(x, 0f, z) * newRotation;
            oldRotation = transform.rotation;
            lerpTime = 0f;
        }

        //myShaker.Shake(CamShake);
    }

    //public void Shakes()
    //{

    //    if ((Input.GetKeyDown(KeyCode.W) || SwipeManager.IsSwipingUpRight()) && !isFront)
    //    {
    //        myShaker.Shake(CamShake);

    //    }
    //    else if ((Input.GetKeyDown(KeyCode.S) || SwipeManager.IsSwipingDownLeft()) && !isBack)
    //    {
    //        myShaker.Shake(CamShake);
    //        Debug.Log("Shake");
    //    }
    //}
}
