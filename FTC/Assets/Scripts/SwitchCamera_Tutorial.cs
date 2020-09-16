using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SwitchCamera_Tutorial : MonoBehaviour
{

    public GameObject Cube1, Cube2, Cube3, Cube4, Cube5, Cube6;
    public TutorialMovement player; 
    public float size, time, Y;

    public GameObject LCube1, LCube2, LCube3, LCube4, LCube5, LCube6;
    public float Lsize, Ltime, L_Y;

    public Image View;
    public GameObject PEf1;
    public GameObject PEf2;

    public GameObject LastCube;
    public GameObject Player;

    public GameObject dust1;
    public GameObject dust2;
    public GameObject dust3;
    public GameObject section;

    public float fov;
    public Camera Cam;
    public GameObject last;

    public Image BG;
    public TextMeshProUGUI P1;
    public TextMeshProUGUI P2;
    public TextMeshProUGUI P3;
    public TextMeshProUGUI TTB;

    public GameObject SS1;
    public GameObject SS2;
    public GameObject Portal1;
    public GameObject L1;
    public GameObject L2;
    public GameObject L3;
    public GameObject L4;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(SwitchCam());
        }   
    }

    IEnumerator SwitchCam()
    {
        yield return new WaitForSeconds(0.3f);
        player.enabled = false;
        yield return new WaitForSeconds(1);
        Cube1.transform.DOScaleY(size, time); Cube1.transform.DOMoveY(Y, 1);
        Cube2.transform.DOScaleY(size, time); Cube2.transform.DOMoveY(Y, 1);
        Cube3.transform.DOScaleY(size, time); Cube3.transform.DOMoveY(Y, 1);
        Cube4.transform.DOScaleY(size, time); Cube4.transform.DOMoveY(Y, 1);
        Cube5.transform.DOScaleY(size, time); Cube5.transform.DOMoveY(Y, 1);
        Cube6.transform.DOScaleY(size, time); Cube6.transform.DOMoveY(Y, 1);
        //yield return new WaitForSeconds(0.3f);
        //section.SetActive(false);
        BG.DOFade(1, 1);
        yield return new WaitForSeconds(1f);
        P1.DOFade(1, 1.5f);
        //yield return new WaitForSeconds(1);
        PEf1.SetActive(false);
        PEf2.SetActive(false);
        player.transform.DOScale(0f, 1f);
        LastCube.transform.DOScaleY(size, time); LastCube.transform.DOMoveY(-20, 1);
        dust1.transform.DOMoveY(-40, 1);
        dust2.transform.DOMoveY(-40, 1);
        dust3.transform.DOMoveY(-40, 1);
        //yield return new WaitForSeconds(1f);
        dust1.SetActive(false);
        dust2.SetActive(false);
        dust3.SetActive(false);
        SS1.SetActive(false);
        SS2.SetActive(false);
        L1.SetActive(false);
        L2.SetActive(false);
        L3.SetActive(false);
        L4.transform.DOLocalMoveY(-300, 1);
        Portal1.SetActive(false);
        yield return new WaitForSeconds(2f);
        P2.DOFade(1, 1);
        yield return new WaitForSeconds(2.1f);
        P3.DOFade(1, 1);
        yield return new WaitForSeconds(2.1f);
        Cam.DOOrthoSize(fov, 2);
        P1.DOFade(0, 1);
        P2.DOFade(0, 1);
        P3.DOFade(0, 1);
        last.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        BG.DOFade(0, 1);
        yield return new WaitForSeconds(1);
        TTB.transform.DOLocalMoveZ(-3.5f, 1.5F);
        yield return new WaitForSeconds(0.5f);
        anim.enabled = true;
    }
}
