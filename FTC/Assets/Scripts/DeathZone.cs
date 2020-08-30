using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public PostProcessVolume ppv;
    private ColorGrading Cg;
    private DepthOfField dof;
    public GameObject GameOver;
    public GameObject MainUI;
    private GameObject player;
    public LifeSystem lives;
    public GameObject refillLives;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ppv.profile.TryGetSettings(out Cg);
        ppv.profile.TryGetSettings(out dof);
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
            lives.lives--;
            Destroy(player,2);
            if(lives.lives == 0)
            {
                GameOver.SetActive(false);
                MainUI.SetActive(false);
                refillLives.SetActive(true);
            }
        }
    }

    public void pauseButton()
    {
        dof.enabled.value = enabled;
    }
}
