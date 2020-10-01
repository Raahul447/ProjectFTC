using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class TutorialDisable : MonoBehaviour
{

    public TutorialMovement Tm;
    public TutorialDisable TD;
    public float time;

    public bool isDone = false;

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
        if(other.gameObject.tag == "Player")
        {
            if (isDone)
            {
                StartCoroutine(DisableMov());
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator DisableMov()
    {
        yield return new WaitForSeconds(0.1f);
        Tm.enabled = false;
        yield return new WaitForSeconds(time);
        Tm.enabled = true;
        yield return new WaitForSeconds(0.3f);
        TD.enabled = false;
        isDone = false;
    }
}
