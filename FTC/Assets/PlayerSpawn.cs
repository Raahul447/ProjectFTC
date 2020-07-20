using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSpawn : MonoBehaviour
{
    private GameObject player;
    public float Y,time = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            //GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = false;
            StartCoroutine(movePlayer());
        }
    }

    IEnumerator movePlayer()
    {
        yield return new WaitForSeconds(1f);
        player.transform.DOMoveY(Y, time);
    }
}
