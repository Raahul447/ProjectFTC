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

    [Header("Death Colliders")]
    public GameObject Col1;
    public GameObject Col2;
    public GameObject Col3;
    

    [Header("Collider Values")]
    public float C1Y;
    public float C2Y;
    public float C3Y;

    [Header("Death Colliders Above Platform")]
    public bool doubleCollider = false;
    public GameObject Col4;
    public GameObject Col5;
    public GameObject Col6;

    [Header("Double Collider Values")]
    public float C4Y;
    public float C5Y;
    public float C6Y;

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
                Col1.transform.DOMoveY(C1Y, time);
                if(doubleCollider)
                {
                    Col4.transform.DOMoveY(C4Y, time);
                }
            }
            if (P2B)
            {
                P2.transform.DOMoveY(P2Y, time);
                Col2.transform.DOMoveY(C2Y, time);
                if (doubleCollider)
                {
                    Col5.transform.DOMoveY(C5Y, time);
                }
            }
            if (P3B)
            {
                P3.transform.DOMoveY(P3Y, time);
                Col3.transform.DOMoveY(C3Y, time);
                if (doubleCollider)
                {
                    Col6.transform.DOMoveY(C6Y, time);
                }
            }
            //gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
