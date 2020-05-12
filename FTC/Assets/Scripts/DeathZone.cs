using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public PostProcessVolume ppv;
    private ColorGrading Cg;
    public GameObject GameOver;
    public GameObject MainUI;

    // Start is called before the first frame update
    void Start()
    {
        ppv.profile.TryGetSettings(out Cg);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Cg.saturation.value = -100;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = false;
            GameOver.SetActive(true);
            MainUI.SetActive(false);
        }
    }
}
