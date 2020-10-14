using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSpawn : MonoBehaviour
{
    [Header("Player")]
    public GameObject[] Player;
    public float spawn_Timer;

    [Header("Movement Scripts")]
    public FinalMovement_1 player1;
    public FinalMovement_2 player2;
    public FinalMovement_3 player3;
    public FinalMovement_4 player4;

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
        yield return new WaitForSeconds(0.3f);
        player1.enabled = true;
        player2.enabled = true;
        player3.enabled = true;
        player4.enabled = true;
        yield return new WaitForSeconds(0.5f);
    }
}
