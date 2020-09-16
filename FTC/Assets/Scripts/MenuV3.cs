using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class MenuV3 : MonoBehaviour
{

    public GameObject MenuObj1;
    public GameObject MenuObj2;
    public GameObject MenuObj3;
    public GameObject MenuObj4;

    // Start is called before the first frame update
    void Start()
    {
        MenuObj1.transform.DOLocalMoveZ(-2.2f, 1);
        MenuObj2.transform.DOLocalMoveZ(-2.2f, 2);
        MenuObj3.transform.DOLocalMoveZ(-2.2f, 3);
        MenuObj4.transform.DOLocalMoveZ(-2.2f, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
