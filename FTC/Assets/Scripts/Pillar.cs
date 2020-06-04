using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public CubesTypes CT;
    public GameObject platform;
    public float y, time;
    public bool isX = false, isY = false, isZ = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (CT.isStep)
        {

            if (isX)
            {
                transform.DOMoveX(y, time);
            }
            else if (isZ)
            {
                transform.DOMoveZ(y, time);
            }
            else if (isY)
            {
                transform.DOMoveY(y, time);
            }
        }
    }
}
