using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSpawn : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            player.GetComponent<Movement>().enabled = false;
            StartCoroutine(movePlayer());
        }
    }

    IEnumerator movePlayer()
    {
        yield return new WaitForSeconds(1f);
        player.GetComponent<Rigidbody>().isKinematic = false;
    }
}
