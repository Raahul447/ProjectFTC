using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Diamond : MonoBehaviour
{

    public float speed;
    public GameObject diamond;

    public bool isPlayerUnder = false;

    public float yPos;
    public float time;

    public Material m_Material;
    public Material g_Material;

    // Start is called before the first frame update
    void Start()
    {
        diamond.transform.DOLocalMoveY(yPos, time);
        m_Material = GetComponentInChildren<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        var down = Vector3.down;

        RaycastHit hit;

        Debug.DrawRay(transform.position, down * 4, Color.white);

        if (Physics.Raycast(transform.position, down, out hit, 4))
        {
            //Debug.Log("Left Hit");
            if (hit.collider.gameObject.tag == "Player")
            {
                isPlayerUnder = true;
            }
        }

        if(isPlayerUnder)
        {
            StartCoroutine(DiamondEnd());
        }

        transform.Rotate(new Vector3(0, Time.deltaTime * speed, 0));
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        StartCoroutine(DiamondEnd());
    //    }
    //}

    IEnumerator DiamondEnd()
    {
        diamond.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), .5f);
        yield return new WaitForSeconds(.5f);
        diamond.GetComponentInChildren<Renderer>().material = g_Material;
        yield return new WaitForSeconds(0.7f);
        diamond.transform.DOScale(new Vector3(1, 1, 1), 1);
        //yield return new WaitForSeconds(0.5f);
        //diamond.SetActive(false);
    }
}
