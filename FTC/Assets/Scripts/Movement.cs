using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System;
using System.Linq;
using MilkShake;

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

    public TextMeshProUGUI Score;

    //public ScoreCal sc;
    public int _Moves = 0;

    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canMoveForward = true;
    public bool canMoveBackward = true;

    public float raycastHitDistance = 2;

    public Shaker myShaker;
    public ShakePreset CamShake;

    public CubesTypes CT;
    public GameOver GO;

    [Header("Hearts")]
    public Image[] Hearts;

    public Movement2 Mv2;
    public PauseMenu_New PN;

    public AudioSource pSound;

    public LifeSystem Ls;

    public RefillLives TryAgainLives;
    public Ad_Manager Am;

    void Start()
    {
        newRotation = oldRotation = transform.rotation;
        Mv2 = GameObject.Find("Player").GetComponent<Movement2>();
        Ls = GameObject.Find("Life System").GetComponent<LifeSystem>();
        Am = GameObject.Find("AdManager").GetComponent<Ad_Manager>();
        //GO = GameObject.Find("GameOverCanvas").GetComponent<GameOver>();
        //pSound = GameObject.Find("Player").GetComponent<AudioSource>();
        //lives = GameObject.FindGameObjectWithTag("LifeSystem");
    }

    void Update()
    {
        UpdateRotationState();
        if (lerpTime < 1f)
        {
            lerpTime += Time.deltaTime * lerpSpeed;
            transform.rotation = Quaternion.Lerp(oldRotation, newRotation, lerpTime);
        }

        if (_Moves <= CT.ThreeStars)
        {
            Score.text = _Moves.ToString() + "/" + CT.ThreeStars;
        }
        else if (_Moves > CT.ThreeStars && _Moves <= CT.TwoStars)
        {
            Score.text = _Moves.ToString() + "/" + CT.TwoStars;
        }
        else if (_Moves <= CT.OneStar && _Moves > CT.TwoStars)
        {
            Score.text = _Moves.ToString() + "/" + CT.OneStar;
        }
        else if(_Moves > CT.OneStar)
        {
            Score.text = "0";
            if (Ls.currentLives <= 1)
            {
                TryAgainLives.enabled = true;
                Mv2.enabled = true;
                Debug.Log("No");
            }
            else if (Ls.currentLives > 0)
            {
                GO.enabled = true;
                Mv2.enabled = true;
                Debug.Log("YEs");
            }
        }

    }

    public void UpdateRotationState()
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
            //Debug.Log("Left Hit");
            if (hit.collider.gameObject.tag == "Barrier")
            {
                canMoveLeft = false;
            }
        }

        if (Physics.Raycast(transform.position, -forward, out hit, raycastHitDistance))
        {
            //Debug.Log("Back Hit");
            if (hit.collider.gameObject.tag == "Barrier")
            {
                canMoveBackward = false;
            }
        }

        if (Physics.Raycast(transform.position, forward, out hit, raycastHitDistance))
        {
            //Debug.Log("Front Hit");
            if (hit.collider.gameObject.tag == "Barrier")
            {
                canMoveForward = false;
            }
        }


        if (Physics.Raycast(transform.position, right, out hit, raycastHitDistance))
        {
            //Debug.Log("Right Hit");
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
                PN.PauseMask.transform.DOLocalMoveY(2, 0.4f);
                PN.isPaused = false;
                Am.HideBannerAd();
                //pSound.Play();
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
                PN.PauseMask.transform.DOLocalMoveY(2, 0.4f);
                PN.isPaused = false;
                Am.HideBannerAd();
                //pSound.Play();
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
                PN.PauseMask.transform.DOLocalMoveY(2, 0.4f);
                PN.isPaused = false;
                Am.HideBannerAd();
                //pSound.Play();
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
                PN.PauseMask.transform.DOLocalMoveY(2, 0.4f);
                PN.isPaused = false;
                Am.HideBannerAd();
                //pSound.Play();
            }
        }

        // if rotation is nonzero, apply it
        if (x != 0f || z != 0f)
        {
            newRotation = Quaternion.Euler(x, 0f, z) * newRotation;
            oldRotation = transform.rotation;
            lerpTime = 0f;
        }

        Shakes();

    }

    public void Shakes()
    {

        if ((Input.GetKeyDown(KeyCode.W) || SwipeManager.IsSwipingUpRight() || SwipeManager.IsSwipingUp() || SwipeManager.IsSwipingRight()) && !canMoveForward)
        {
            myShaker.Shake(CamShake);
            Handheld.Vibrate();
        }
        else if ((Input.GetKeyDown(KeyCode.A) || SwipeManager.IsSwipingUpLeft()) && !canMoveLeft)
        {
            myShaker.Shake(CamShake);
            Handheld.Vibrate();
        }
        else if ((Input.GetKeyDown(KeyCode.S) || SwipeManager.IsSwipingDownLeft() || SwipeManager.IsSwipingDown() || SwipeManager.IsSwipingLeft()) && !canMoveBackward)
        {
            myShaker.Shake(CamShake);
            Handheld.Vibrate();

        }
        else if ((Input.GetKeyDown(KeyCode.D) || SwipeManager.IsSwipingDownRight()) && !canMoveRight)
        {
            myShaker.Shake(CamShake);
            Handheld.Vibrate();
        }
    }
} 

