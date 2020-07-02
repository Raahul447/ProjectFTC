using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
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

    public Text Score;

    //public ScoreCal sc;
    public int _Moves = 0;

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

        Score.text = _Moves.ToString();
    }
    void UpdateRotationState()
    {
        // Get the rotation, if any
        float x = 0f, z = 0f;

        //Left
        if (Input.GetKeyDown(KeyCode.A) || SwipeManager.IsSwipingUpLeft())
        {
            z = 90f;
            transform.position += Vector3.left * 2;
            _Moves += 1;
        }

        //Down
        if (Input.GetKeyDown(KeyCode.S) || SwipeManager.IsSwipingDownLeft() || SwipeManager.IsSwipingDown() | SwipeManager.IsSwipingLeft())
        {
            x = -90f;
            transform.position += Vector3.back * 2;
            _Moves += 1;
        }

        //Up
        if (Input.GetKeyDown(KeyCode.W) || SwipeManager.IsSwipingUpRight() || SwipeManager.IsSwipingUp() || SwipeManager.IsSwipingRight())
        {
            x = 90f;
            transform.position += Vector3.forward * 2;
            _Moves += 1;
        }

        //Right
        if (Input.GetKeyDown(KeyCode.D) ||SwipeManager.IsSwipingDownRight())
        {
            z = -90f;
            transform.position += Vector3.right * 2;
            _Moves += 1;
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
