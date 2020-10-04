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

    // Start is called before the first frame update
    void Start()
    {
        DesertTheme = (AudioClip)Resources.Load("SoundEffects/Desert_Theme");
        MountainTheme = (AudioClip)Resources.Load("SoundEffects/Mountain_Theme");
        SnowTheme = (AudioClip)Resources.Load("SoundEffects/Mountain_Theme");
        LavaTheme = (AudioClip)Resources.Load("SoundEffects/Mountain_Theme");
        LevelSong();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelSong()
    {
        if(this.gameObject.tag == "Menu")
        {
            Main.clip = MainTheme;
            Main.Play();
            Main.DOFade(0.3f, 10);
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
            Main.DOFade(0, 3);
        }
        else if (levels == "Desert")
        {
            Main.DOFade(0, 3);
        }
        else if (levels == "Mountain")
        {
            Main.DOFade(0, 3);
        }
        else if (levels == "Snow")
        {
            Main.DOFade(0, 3);
        }
        else if (levels == "Lava")
        {
            Main.DOFade(0, 3);
        }
    }

}
