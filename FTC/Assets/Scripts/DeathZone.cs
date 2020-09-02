using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    public PostProcessVolume ppv;
    private ColorGrading Cg;
    private DepthOfField dof;
    public GameObject GameOver;
    public GameObject MainUI;
    private GameObject player;
    [SerializeField]
    private GameObject lives;
    public GameObject refillLives;

    // Start is called before the first frame update
    void Start()
    {
        lives = GameObject.FindGameObjectWithTag("LifeSystem");
        //refillLives = GameObject.FindGameObjectWithTag("RefillLives");
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
            lives.GetComponent<LifeSystem>().lives--;
            //lives.lives--;
            Destroy(player,2);
            if(lives.GetComponent<LifeSystem>().lives == 0)
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
