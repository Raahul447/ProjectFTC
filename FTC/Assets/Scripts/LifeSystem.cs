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
    public HeartsSystem Hs;

    void Start()
    {
        Hs = GameObject.Find("HeartsLives").GetComponent<HeartsSystem>();
    }

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
        Hs = GameObject.Find("HeartsLives").GetComponent<HeartsSystem>();
        //livesText = GameObject.FindGameObjectWithTag("LivesTextCanvas").GetComponentInChildren<Text>();

        if (lives < maxLives)
        {
            timerForLife += Time.deltaTime;
            if (timerForLife > lifeReplenishTime)
            {
                lives++;
                timerForLife = 0;

                if(lives == 3)
                {
                    Hs.ThreeAdd();
                }
                else if(lives == 2)
                {
                    Hs.TwoAdd();
                }
                else if(lives == 1)
                {
                    Hs.OneAdd();
                }
            }
        }

        //livesText.text = currentLives.ToString();
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
