using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Audio : MonoBehaviour
{

    public GameObject R;
    public GameObject L;

    // Start is called before the first frame update
    void Start()
    {
        if(AudioListener.volume == 1)
        {
            R.SetActive(true);
            L.SetActive(false);
        }
        else
        {
            R.SetActive(false);
            L.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
