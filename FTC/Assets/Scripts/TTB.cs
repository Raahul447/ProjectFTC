using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class TTB : MonoBehaviour
{

    public TextMeshProUGUI ttb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        ttb.DOFade(1, 1);
        yield return new WaitForSeconds(1);
        ttb.DOFade(0, 1);
        yield return new WaitForSeconds(1);
        ttb.DOFade(1, 1);
    }
}
