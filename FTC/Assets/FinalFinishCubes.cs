using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinalFinishCubes : MonoBehaviour
{
    [Header("Final Light")]
    public GameObject finaleLight;

    [Header("Player Movements")]
    public FinalMovement_1 player1;
    public FinalMovement_2 player2;
    public FinalMovement_3 player3;
    public FinalMovement_4 player4;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FinalMove());
    }

    IEnumerator FinalMove()
    {
        finaleLight.SetActive(true);
        finaleLight.transform.DOLocalMoveY(-10.6f, 2f);
        yield return new WaitForSeconds(.1f);
        player1.enabled = false;
        player2.enabled = false;
        player3.enabled = false;
        player4.enabled = false;
    }
}
