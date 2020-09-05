using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Linq;

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

    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canMoveForward = true;
    public bool canMoveBackward = true;

    public float raycastHitDistance = 2;

    //public List<Transform> pathPoints = new List<Transform>();
    //[SerializeField]
    //private Transform playerPos;

    //public void OnDrawGizmos()
    //{
    //    if (pathPoints == null || pathPoints.Count < 2)
    //    {
    //        return;
    //    }
    //    for (var i = 1; i < pathPoints.Count; i++)
    //    {
    //        Gizmos.DrawLine(pathPoints[i - 1].position, pathPoints[i].position);
    //    }
    //}
    void Start()
    {
        //playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //if (pathPoints == null)
        //{
        //    Debug.LogError("Movement Path cannot be null, I must have a path to follow.", gameObject);
        //    return;
        //}
        newRotation = oldRotation = transform.rotation;
    }

    void Update()
    {
        // get input from user and update state if need be
        //if (pathPoints.Equals(playerPos))
        //{
        UpdateRotationState();
        //}
        //else
        //{
        //    Debug.Log("Can't Move");
        //}
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
        var forward = Vector3.forward;
        var right = Vector3.right;

        canMoveBackward = true;
        canMoveForward = true;
        canMoveLeft = true;
        canMoveRight = true;

        RaycastHit hit;

        Debug.DrawRay(transform.position, forward * raycastHitDistance, Color.red);
        Debug.DrawRay(transform.position, -forward * raycastHitDistance, Color.green);
        Debug.DrawRay(transform.position, -right * raycastHitDistance, Color.white);
        Debug.DrawRay(transform.position, right * raycastHitDistance, Color.black);

        if (Physics.Raycast(transform.position, -right, out hit, raycastHitDistance))
        {
            Debug.Log("Left Hit");
            if (hit.collider.gameObject.tag == "Barrier")
            {
                canMoveLeft = false;
            }
        }

        if (Physics.Raycast(transform.position, -forward, out hit, raycastHitDistance))
        {
            Debug.Log("Back Hit");
            if (hit.collider.gameObject.tag == "Barrier")
            {
                canMoveBackward = false;
            }
        }

        if (Physics.Raycast(transform.position, forward, out hit, raycastHitDistance))
        {
            Debug.Log("Front Hit");
            if (hit.collider.gameObject.tag == "Barrier")
            {
                canMoveForward = false;
            }
        }

        if (Physics.Raycast(transform.position, right, out hit, raycastHitDistance))
        {
            Debug.Log("Right Hit");
            if (hit.collider.gameObject.tag == "Barrier")
            {
                canMoveRight = false;
            }
        }

        // Get the rotation, if any
        float x = 0f, z = 0f;

        //Left
        if (canMoveLeft)
        {
            if (Input.GetKeyDown(KeyCode.A) || SwipeManager.IsSwipingUpLeft())
            {
                z = 90f;
                transform.position += Vector3.left * 2;
                _Moves += 1;
            }
        }

        //Down
        if (canMoveBackward)
        {
            if (Input.GetKeyDown(KeyCode.S) || SwipeManager.IsSwipingDownLeft() || SwipeManager.IsSwipingDown() | SwipeManager.IsSwipingLeft())
            {
                x = -90f;
                transform.position += Vector3.back * 2;
                _Moves += 1;
            }
        }

        //Up
        if (canMoveForward)
        {
            if (Input.GetKeyDown(KeyCode.W) || SwipeManager.IsSwipingUpRight() || SwipeManager.IsSwipingUp() || SwipeManager.IsSwipingRight())
            {
                x = 90f;
                transform.position += Vector3.forward * 2;
                _Moves += 1;
            }
        }

        //Right
        if (canMoveRight)
        {
            if (Input.GetKeyDown(KeyCode.D) || SwipeManager.IsSwipingDownRight())
            {
                z = -90f;
                transform.position += Vector3.right * 2;
                _Moves += 1;
            }
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

