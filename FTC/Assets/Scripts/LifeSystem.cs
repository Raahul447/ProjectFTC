using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{

    public int maxLives = 2;
    public float lifeReplenishTime = 30f;
    [SerializeField]
    private int currentLives;

    [SerializeField]
    private GameObject livesTextCanvas;
    [SerializeField]
    private Text livesText;

    public double timerForLife;

    private DateTime timeOfPause;
    public Image Hearts1;
    public Image Hearts1Min;
    public Image Hearts2;
    public Image Hearts2Min;
    public Image Hearts3;
    public Image Hearts3Min;

    public Movement Mv;
    public CubesTypes Ct;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Lives"))
        {
            PlayerPrefs.SetString("LifeUpdateTime", DateTime.Now.ToString());
        }
        lives = PlayerPrefs.GetInt("Lives", maxLives);

        
        if (lives < maxLives)
        {
            float timerToAdd = (float)(System.DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("LifeUpdateTime"))).TotalSeconds;
            UpdateLives(timerToAdd);
        }


        if (Ct == null)
        {
            Debug.Log("Chill");
            return;
        }
    }

    public int lives
    {
        set
        {
            currentLives = value;
            PlayerPrefs.SetInt("Lives", currentLives);
        }
        get
        {
            return currentLives;
        }
    }

    private void Update()
    {
        livesTextCanvas = GameObject.FindGameObjectWithTag("LivesTextCanvas");
        livesText = GameObject.FindGameObjectWithTag("LivesTextCanvas").GetComponentInChildren<Text>();
        Mv = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        //Ct = GameObject.FindGameObjectWithTag("End Cube").GetComponent<CubesTypes>();
        Ct = GameObject.Find("FinalCube").GetComponent<CubesTypes>();

        if (Mv._Moves == Ct.OneStar)
        {
           lives--;
        }

        if (lives < maxLives)
        {
            timerForLife += Time.deltaTime;
            if (timerForLife > lifeReplenishTime)
            {
                lives++;
                timerForLife = 0;
            }
        }

        //livesText.text = currentLives.ToString();

        if(lives == 2)
        {
            Hearts3.DOFade(1, 1);
            Hearts3Min.DOFade(0, 0.5f);
        }
        else if(lives == 1)
        {
            Hearts2.DOFade(1, 1);
            Hearts2Min.DOFade(0, 0.5f);
        }
        else if (lives == 0)
        {
            Hearts1.DOFade(1, 1);
            Hearts1Min.DOFade(0, 0.5f);
        }
    }

    void UpdateLives(double timerToAdd)
    {
        if (lives < maxLives)
        {
            int livesToAdd = Mathf.FloorToInt((float)timerToAdd / lifeReplenishTime);
            timerForLife = (float)timerToAdd % lifeReplenishTime;
            lives += livesToAdd;
            if (lives > maxLives)
            {
                lives = maxLives;
                timerForLife = 0;
            }
        }
        PlayerPrefs.SetString("LifeUpdateTime", DateTime.Now.ToString());
    }

    void OnApplicationPause(bool isPause)
    {
        if (isPause)
        {
            timeOfPause = System.DateTime.Now;
        }
        else
        {
            if (timeOfPause == default(DateTime))
            {
                timeOfPause = System.DateTime.Now;
            }
            float timerToAdd = (float)(System.DateTime.Now - timeOfPause).TotalSeconds;
            timerForLife += timerToAdd;
            UpdateLives(timerForLife);
        }
    }

    public string showLifeTimeInMinutes()
    {
        float timeLeft = lifeReplenishTime - (float)timerForLife;
        int min = Mathf.FloorToInt(timeLeft / 60);
        int sec = Mathf.FloorToInt(timeLeft % 60);
        return min + ":" + sec.ToString("00");
    }
}
