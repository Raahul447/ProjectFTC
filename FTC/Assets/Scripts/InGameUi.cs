using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InGameUi : MonoBehaviour
{
    public GameObject Moves;
    //public GameObject Lives;
    public GameObject Settings;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InGame()
    {
        yield return new WaitForSeconds(0.1f);
        Moves.transform.DOLocalMoveY(-3, 0.7f);
        //Lives.transform.DOLocalMoveY(-612, 0.7f);
        yield return new WaitForSeconds(0.4f);
        Settings.transform.DOLocalMoveY(2, 0.7f);
    }

    IEnumerator OutGame()
    {
        yield return new WaitForSeconds(0.1f);
        Moves.transform.DOLocalMoveY(-99.01001f, 0.7f);
        //Lives.transform.DOLocalMoveY(-512.14f, 0.7f);
        yield return new WaitForSeconds(0.4f);
        Settings.transform.DOLocalMoveX(-513.2f, 0.7f);
    }
}
