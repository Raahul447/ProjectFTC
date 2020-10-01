using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelIcons : MonoBehaviour
{
    public GameObject Lvl;


    // Start is called before the first frame update
    void Start()
    {
        Lvl = this.gameObject;
        Lvl.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.3f);
    }

    private void OnEnable()
    {
        Lvl = this.gameObject;
        Lvl.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
