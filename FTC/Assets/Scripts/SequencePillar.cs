using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SequencePillar : MonoBehaviour
{
    [Header("Sequence Pillars")]
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;

    [Header("Combination Values")]
    public float P1Y;
    public float P2Y;
    public float P3Y;

    public float time;

    [Header("Sequence Bools")]
    public bool P1B;
    public bool P2B;
    public bool P3B;

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
        if(other.gameObject.tag == "Player" && this.gameObject.tag == "Sequence")
        {
            if (P1B)
            {
                P1.transform.DOMoveY(P1Y, time);
            }
            if (P2B)
            {
                P2.transform.DOMoveY(P2Y, time);
            }
            if (P3B)
            {
                P3.transform.DOMoveY(P3Y, time);
            }
        }
    }
}
