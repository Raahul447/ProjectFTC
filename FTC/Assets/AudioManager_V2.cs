using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine;

public class AudioManager_V2 : MonoBehaviour
{
    [Header("Aduio Source")]
    public AudioSource Main;

    [Header("Audio Clip")]
    public AudioClip MainTheme;
    public AudioClip DesertTheme;
    public AudioClip MountainTheme;
    public AudioClip SnowTheme;
    public AudioClip LavaTheme;

    public string levels;
    public int volume;

    // Start is called before the first frame update
    void Start()
    {
        volume = PlayerPrefs.GetInt("volume", 1);
        MainTheme = (AudioClip)Resources.Load("Sounds/Tumble Theme");
        DesertTheme = (AudioClip)Resources.Load("Sounds/Desert_Theme");
        MountainTheme = (AudioClip)Resources.Load("Sounds/Mountain_Theme");
        SnowTheme = (AudioClip)Resources.Load("Sounds/Snow_Theme");
        LavaTheme = (AudioClip)Resources.Load("Sounds/Lava_ThemeTumble_The_Game (2)");
        LevelSong();
        volume = PlayerPrefs.GetInt("volume", 1);
        if (volume == 1)
        {
            AudioListener.volume = 1f;
        }
        else if (volume == 0)
        {
            AudioListener.volume = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //volume = PlayerPrefs.GetInt("volume", 1);
        //if (volume == 1)
        //{
        //    AudioListener.volume = 1f;
        //}
        //else if(volume == 0)
        //{
        //    AudioListener.volume = 0f;
        //}
    }

    public void LevelSong()
    {
        if(this.gameObject.tag == "Menu")
        {
            Main.clip = MainTheme;
            Main.Play();
            Main.DOFade(0.5f, 5);
        }
        else if(this.gameObject.tag == "Desert")
        {
            Main.clip = DesertTheme;
            Main.Play();
            Main.DOFade(0.3f, 10);
        }
        else if (this.gameObject.tag == "Mountain")
        {
            Main.clip = MountainTheme;
            Main.Play();
            Main.DOFade(0.3f, 10);
        }
        else if (this.gameObject.tag == "Snow")
        {
            Main.clip = SnowTheme;
            Main.Play();
            Main.DOFade(0.3f, 10);
        }
        else if (this.gameObject.tag == "Lava")
        {
            Main.clip = LavaTheme;
            Main.Play();
            Main.DOFade(0.3f, 10);
        }
    }

    public void endFade()
    {
        if (levels == "Menu")
        {
            Main.DOFade(0.05f, 3);
        }
        else if (levels == "Desert")
        {
            Main.DOFade(0.05f, 3);
        }
        else if (levels == "Mountain")
        {
            Main.DOFade(0.05f, 3);
        }
        else if (levels == "Snow")
        {
            Main.DOFade(0.05f, 3);
        }
        else if (levels == "Lava")
        {
            Main.DOFade(0.05f, 3);
        }
    }

}
