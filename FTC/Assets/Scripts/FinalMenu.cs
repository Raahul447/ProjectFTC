using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class FinalMenu : MonoBehaviour
{
    [Header("Tap to Continue")]
    public GameObject Title;
    public GameObject TTC;
    public GameObject byGame;

    [Header("Menu Buttons")]
    public GameObject Play;
    public GameObject LevelSelect;
    public GameObject Settings;
    public GameObject Credits;

    [Header("Cubes")]
    public GameObject Player;
    public GameObject Bldg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(TitleSeq());
        }
    }


    IEnumerator TitleSeq()
    {
        Title.transform.DOLocalMoveY(254, 1f);
        TTC.SetActive(false);
        yield return new WaitForSeconds(0.6f);
        byGame.transform.DOLocalMoveY(-71.6f, 1);
        yield return new WaitForSeconds(0.1f);
        byGame.SetActive(true);
        Bldg.transform.DOScale(new Vector3(2, 16.62679f, 2), 0.7f);
        yield return new WaitForSeconds(0.3f);
        Player.transform.DOScale(new Vector3(2, 2, 2), 1);
    }
}
