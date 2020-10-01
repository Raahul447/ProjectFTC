using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Porta_Tutorial : MonoBehaviour
{
    [Header("Swipe Cubes")]
    public GameObject Cube1, Cube2, Cube3, Cube4, Cube5, Cube7, Cube8;
    public float time;
    public float size;
    public float Y;
    public TutorialMovement player;

    [Header("Portal Cubes")]
    public GameObject PCube1, PCube2, PCube3, PCube4, PCube5, PCube6, PCube7;
    public float Ptime;
    public float Psize;

    public GameObject diamond2;

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
            StartCoroutine(StartPortals());
        }
    }

    IEnumerator StartPortals()
    {
        yield return new WaitForSeconds(0.3f);
        //player.enabled = false;
        yield return new WaitForSeconds(1);
        Cube1.transform.DOScaleY(size, time); Cube1.transform.DOMoveY(Y, 1);
        Cube2.transform.DOScaleY(size, time); Cube2.transform.DOMoveY(Y, 1);
        Cube3.transform.DOScaleY(size, time); Cube3.transform.DOMoveY(Y, 1);
        Cube4.transform.DOScaleY(size, time); Cube4.transform.DOMoveY(Y, 1);
        Cube5.transform.DOScaleY(size, time); Cube5.transform.DOMoveY(Y, 1);
        Cube7.transform.DOScaleY(size, time); Cube7.transform.DOMoveY(Y, 1);
        Cube7.SetActive(false);
        Cube8.transform.DOScaleY(size, time); Cube8.transform.DOMoveY(Y, 1);
        yield return new WaitForSeconds(0.5F);
        PCube1.transform.DOLocalMoveY(-8.42f, 1);
        PCube1.transform.DOScaleY(Psize, time); Cube1.transform.DOMoveY(Y, 1);
        PCube2.transform.DOLocalMoveY(-8.42f, 1);
        PCube2.transform.DOScaleY(Psize, time); Cube2.transform.DOMoveY(Y, 1);
        PCube3.transform.DOLocalMoveY(-8.42f, 1);
        PCube3.transform.DOScaleY(Psize, time); Cube3.transform.DOMoveY(Y, 1);
        PCube6.SetActive(true);
        PCube6.transform.DOLocalMoveY(-7.9771f, 0.7f);
        PCube7.SetActive(true);
        PCube7.transform.DOLocalMoveY(-7.94f, 0.7f);
        diamond2.SetActive(true);
        //player.enabled = true;
    }
}
