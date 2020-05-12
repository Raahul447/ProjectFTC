using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public CubesTypes CT;
    public float y, time;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (CT.isStep)
        {
            transform.DOMoveY(y, time);
        }
    }
}
