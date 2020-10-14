using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outside_23 : MonoBehaviour
{
    public FinalMovement_3 Tm;

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
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Front")
        {
            Tm.isFront = true;
            Tm.isBack = false;
        }
        else if (other.gameObject.tag == "Player" && this.gameObject.tag == "Back")
        {
            Tm.isBack = true;
            Tm.isFront = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.tag == "Player" && this.gameObject.tag == "Front")
            {
                Tm.isFront = true;
                Tm.isBack = false;
            }
            else if (other.gameObject.tag == "Player" && this.gameObject.tag == "Back")
            {
                Tm.isBack = true;
                Tm.isFront = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Tm.isFront = true;
        Tm.isBack = true;
    }
}
