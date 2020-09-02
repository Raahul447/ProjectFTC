using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Block_Spawn : MonoBehaviour
{
    public float time;
    public float size;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOScaleY(size, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
