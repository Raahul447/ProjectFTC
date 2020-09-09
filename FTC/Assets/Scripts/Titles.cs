using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Titles : MonoBehaviour
{
    [Header("T_Tumble")]
    public GameObject T_1;
    public GameObject T_2;
    public float ysize, ypos, ytime;
    public float zsize, zpos, ztime;

    [Header("U_Tumble")]
    public GameObject U_1;
    public GameObject U_2;
    public GameObject U_3;
    public float y2size, y2pos, y2time;
    public float z2size, z2pos, z2time;

    [Header("M_Tumble")]
    public GameObject M_1;
    public GameObject M_2;
    public GameObject M_3;
    public GameObject M_4;
    public float y3size, y3pos, y3time;
    public float y4size, y4pos;
    public float z3size, z3pos, z3time;

    [Header("B_Tumble")]
    public GameObject B_1;
    public GameObject B_2;
    public GameObject B_3;
    public GameObject B_4;
    public GameObject B_5;
    public GameObject B_6;
    public float y5size, y6size, y7size, y567time;
    public float y5pos, y6pos, y7pos;
    public float z5size, z6size, z7size;
    public float z5pos, z6pos, z7pos;

    [Header("L_Tumble")]
    public GameObject L_1;
    public GameObject L_2;
    public float y8size, y8pos, y8time;
    public float z8size, z8pos, z8time;

    [Header("E_Tumble")]
    public GameObject E_1;
    public GameObject E_2;
    public GameObject E_3;
    public GameObject E_4;
    public float y9size, y9pos, y9time;
    public float z10size, z11size, z12size;
    public float z10pos, z11pos, z12pos;
    public float z10time, z11time, z12time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(T_Titles());
        StartCoroutine(U_Titles());
        StartCoroutine(M_Titles());
        StartCoroutine(B_Titles());
        StartCoroutine(L_Titles());
        StartCoroutine(E_Titles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator T_Titles()
    {
        yield return new WaitForSeconds(1.2f);
        T_1.transform.DOLocalMoveY(ypos, ytime);
        T_1.transform.DOScaleY(ysize, ytime);
        T_2.transform.DOLocalMoveZ(zpos, ztime);
        T_2.transform.DOScaleZ(zsize, ztime);
    }

    IEnumerator U_Titles()
    {
        yield return new WaitForSeconds(1.3f);
        U_1.transform.DOLocalMoveY(y2pos, y2time);
        U_1.transform.DOScaleY(y2size, y2time);
        U_2.transform.DOLocalMoveY(y2pos, y2time);
        U_2.transform.DOScaleY(y2size, y2time);
        U_3.transform.DOScaleZ(z2size, z2time);
    }

    IEnumerator M_Titles()
    {
        yield return new WaitForSeconds(1.4f);
        M_1.transform.DOLocalMoveY(y3pos, y3time);
        M_1.transform.DOScaleY(y3size, y3time);
        M_2.transform.DOLocalMoveY(y4pos, y3time);
        M_2.transform.DOScaleY(y4size, y3time);
        M_3.transform.DOLocalMoveY(y3pos, y3time);
        M_3.transform.DOScaleY(y3size, y3time);
        M_4.transform.DOScaleZ(z3size, z3time);
    }

    IEnumerator B_Titles()
    {
        yield return new WaitForSeconds(1.5f);
        B_1.transform.DOLocalMoveY(y5pos, y567time);
        B_1.transform.DOScaleY(y5size, y567time);
        B_3.transform.DOLocalMoveY(y6pos, y567time);
        B_3.transform.DOScaleY(y6size, y567time);
        B_5.transform.DOLocalMoveY(y7pos, y567time);
        B_5.transform.DOScaleY(y7size, y567time);
        B_2.transform.DOLocalMoveZ(z5pos, y567time);
        B_2.transform.DOScaleZ(z5size, y567time);
        B_4.transform.DOLocalMoveZ(z6pos, y567time);
        B_4.transform.DOScaleZ(z6size, y567time);
        B_6.transform.DOLocalMoveZ(z7pos, y567time);
        B_6.transform.DOScaleZ(z7size, y567time);
    }

    IEnumerator L_Titles()
    {
        yield return new WaitForSeconds(1.6f);
        L_1.transform.DOLocalMoveY(y8pos, y8time);
        L_1.transform.DOScaleY(y8size, y8time);
        L_2.transform.DOLocalMoveZ(z8pos, z8time);
        L_2.transform.DOScaleZ(z8size, z8time);
    }

    IEnumerator E_Titles()
    {
        yield return new WaitForSeconds(1.7f);
        E_1.transform.DOLocalMoveY(y9pos, y9time);
        E_1.transform.DOScaleY(y9size, y9time);
        E_2.transform.DOLocalMoveZ(z10pos, z10time);
        E_2.transform.DOScaleZ(z10size, z10time);
        E_3.transform.DOLocalMoveZ(z11pos, z11time);
        E_3.transform.DOScaleZ(z11size, z11time);
        E_4.transform.DOLocalMoveZ(z12pos, z12time);
        E_4.transform.DOScaleZ(z12size, z12time);
    }
}
