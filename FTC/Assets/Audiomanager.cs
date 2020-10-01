using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class Audiomanager : MonoBehaviour
{
    public static Audiomanager audiomanager;
    public Sounds[] sounds;


    public static Audiomanager Instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        audiomanager = this;

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loopSound;
            s.source.playOnAwake = s.playAwake;
            
        }
    }

    public void Play(string name)
    {
        //when playing sounds, use this syntax       
        //FindObjectOfType<Audiomanager>().Play("INSERT SOUND NAME");

        //float t = 0.0f;

        //Sounds s = Array.Find(sounds, sound => sound.name == name);
        StartCoroutine(AudioFadeIn(name));
        Debug.Log("Play Sound");
    }

    public void Stop(string name)
    {
        //Sounds s = Array.Find(sounds, sound => sound.name == name);
        StartCoroutine(AudioFadeOut(name));
        
        Debug.Log("Stop Sound");
    }

    //public void Volume(string name, float volumeStrength, float duration)
    //{
    //    Sounds s = Array.Find(sounds, sound => sound.name == name);
    //    float currentTime = 0;
    //    float start = s.source.volume;
    //    while (currentTime < duration)
    //    {
    //        currentTime += Time.deltaTime;
    //        s.source.volume = Mathf.Lerp(start, volumeStrength, currentTime/duration);
    //    }
    //    //s.source.Stop();
    //    Debug.Log("Volume");
    //}

    private IEnumerator AudioFadeIn(string name)
    {
        float t = 0.0f;
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        for (t = 0; t < 2.0f; t += Time.deltaTime)
        {
            s.source.volume =  (t / 2);
            yield return null;
        }
        yield break;
    }

    private IEnumerator AudioFadeOut(string name)
    {
        //float t = 0.0f;
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        //for (t = 0; t < 2.0f; t += Time.deltaTime)
        //{
        //    s.source.volume = (1-(t / 2));
        //}
        s.source.Stop();
        yield break;
    }
}

