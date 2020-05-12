using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Random : MonoBehaviour
{
    public GameObject CanvasUI;
    public Movement Mv;

    // Start is called before the first frame update
    void Start()
    {
        Mv = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        Mv.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CanvasON()
    {
        StartCoroutine(cON());
    }

    IEnumerator cON()
    {
        Mv.enabled = true;
        CanvasUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        CanvasUI.SetActive(false);
    }
}
