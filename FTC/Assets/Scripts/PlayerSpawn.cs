using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSpawn : MonoBehaviour
{
    [Header("Player")]
    public GameObject[] Player;
    public float spawn_Timer;

    private void Start()
    {
        StartCoroutine(SpawnPlayer());
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(spawn_Timer);
        foreach(GameObject player in Player)
        {
            player.transform.DOScale(2, 0.3f);
        }
        yield return new WaitForSeconds(0.5f);
    }
}
