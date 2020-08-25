using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerStart : MonoBehaviour
{
    private GameObject player;
    public float Y = 2.444f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            player.GetComponent<Movement>().enabled = true;
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.transform.DOMoveY(Y, 0.5f);
        }
    }
}
