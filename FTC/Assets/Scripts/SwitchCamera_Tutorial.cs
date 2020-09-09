using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        PEf1.SetActive(false);
        PEf2.SetActive(false);
        //yield return new WaitForSeconds(1);
        //LCube1.transform.DOScaleY(Lsize, time); LCube1.transform.DOLocalMoveY(L_Y, 1);
        //LCube2.transform.DOScaleY(Lsize, time); LCube2.transform.DOLocalMoveY(L_Y, 1);
        //LCube3.transform.DOScaleY(Lsize, time); LCube3.transform.DOLocalMoveY(L_Y, 1);
        //LCube4.transform.DOScaleY(Lsize, time); LCube4.transform.DOLocalMoveY(L_Y, 1);
        //LCube5.transform.DOScaleY(Lsize, time); LCube5.transform.DOLocalMoveY(L_Y, 1);
        //LCube6.transform.DOScaleY(Lsize, time); LCube6.transform.DOLocalMoveY(L_Y, 1);
        //View.DOFade(1, 1);
    }
}
