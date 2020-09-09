using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Diamond : MonoBehaviour
{

    public float speed;
    public GameObject diamond;

    public float yPos;
    public float time;

    public Material m_Material;
    public Material g_Material;

    // Start is called before the first frame update
    void Start()
    {
        diamond.transform.DOLocalMoveY(yPos, time);
        m_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * speed, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(DiamondEnd());
        }
    }

    IEnumerator DiamondEnd()
    {
        diamond.GetComponent<Renderer>().material = g_Material;
        yield return new WaitForSeconds(1);
        diamond.transform.DOScale(new Vector3(0, 0, 0), 1);
        yield return new WaitForSeconds(0.5f);
        diamond.SetActive(false);
    }
}
