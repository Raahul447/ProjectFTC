using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Trailer_1 : MonoBehaviour
{

    public TextMeshProUGUI Quote;
    public Image Tldr;
    public GameObject Cubes;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Trailer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Trailer()
    {
        yield return new WaitForSeconds(1);
        Tldr.DOFade(1, 1);
        yield return new WaitForSeconds(2.5f);
        Tldr.DOFade(0, 1);
        yield return new WaitForSeconds(2);
        Quote.DOFade(1, 1.5f);
        yield return new WaitForSeconds(5);
        Quote.DOFade(0, 1);
        yield return new WaitForSeconds(0.5f);
        Cubes.SetActive(true);
    }
}
