using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Movement : MonoBehaviour
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

    void Start()
    {
        newRotation = oldRotation = transform.rotation;
    }

    void Update()
    {
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

        //Left
        if (SwipeManager.IsSwipingUpLeft())
        {
            z = 90f;
            transform.position += Vector3.left * 2;
        }

        //Down
        if (SwipeManager.IsSwipingDownLeft())
        {
            x = -90f;
            transform.position += Vector3.back * 2;
        }

        //Up
        if (SwipeManager.IsSwipingUpRight())
        {
            x = 90f;
            transform.position += Vector3.forward * 2;
        }

        //Right
        if (SwipeManager.IsSwipingDownRight())
        {
            z = -90f;
            transform.position += Vector3.right * 2;
        }

        //Up
        if (Input.GetKeyDown(KeyCode.W))
        {
            //print("Forward");
            x = 90f;
            transform.position += Vector3.forward * 2;
        }
        //Down
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //print("Back");
            x = -90f;
            transform.position += Vector3.back * 2;
        }
        //Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            //print("Left");
            z = 90f;
            transform.position += Vector3.left * 2;
        }
        //Right
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //print("Right");
            z = -90f;
            transform.position += Vector3.right * 2;
        }
        // if rotation is nonzero, apply it
        if (x != 0f || z != 0f)
        {
            newRotation = Quaternion.Euler(x, 0f, z) * newRotation;
            oldRotation = transform.rotation;
            lerpTime = 0f;
        }
    }
}
