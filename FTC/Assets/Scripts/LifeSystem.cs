using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{

    public int maxLives = 2;
    public float lifeReplenishTime = 30f;
    [SerializeField]
    private int currentLives;

    public Text livesText;

    public double timerForLife;

    private DateTime timeOfPause;

    void Awake()
    {
        //DontDestroyOnLoad(this);

        //int numPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        //if (numPlayers != 1)
        //{
        //    Destroy(this.gameObject);
        //}
        //// if more then one music player is in the scene
        ////destroy ourselves
        //else
        //{
        //    DontDestroyOnLoad(gameObject);
        //}

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
        if (lives < maxLives)
        {
            timerForLife += Time.deltaTime;
            if (timerForLife > lifeReplenishTime)
            {
                lives++;
                timerForLife = 0;
            }
        }

        livesText.text = currentLives.ToString();
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
