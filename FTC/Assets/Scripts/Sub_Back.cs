using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Sub_Back : MonoBehaviour
{
    [Header("Objects")]
    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3;
    public GameObject Obj4;
    public GameObject Obj5;

    [Header("Main")]
    public GameObject Main;

    [Header("BG")]
    public GameObject MainBg;
    public Material BG;

    [Header("Lvl Select Elements")]
    public GameObject Desert;
    public GameObject Mountain;
    public GameObject Snow;
    public GameObject Lava;

    [Header("SetBack")]
    public GameObject Set;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sub_B()
    {
        StartCoroutine(GoingBack());
        MainBg.GetComponent<Renderer>().material = BG;
    }

    IEnumerator GoingBack()
    {
        Obj1.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Obj2.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Obj3.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Obj4.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Obj5.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Set.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Main.SetActive(false);
        Desert.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        Mountain.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        Snow.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        Lava.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
    }
}
