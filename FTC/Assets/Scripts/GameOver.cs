using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [Header("Game Over")]
    public PostProcessVolume ppv;
    private ColorGrading Cg;
    private DepthOfField dof;

    [Header("Player")]
    public Movement player;
    public GameObject GameOverObj;

    public InGameUi IG;

    public LifeSystem Ls;

    // Start is called before the first frame update
    void Start()
    {
        ppv.profile.TryGetSettings(out Cg);
        ppv.profile.TryGetSettings(out dof);
        Cg.saturation.value = -100;
        //dof.enabled.value = enabled;
        player.enabled = false;
        StartCoroutine(OutGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OutGame()
    {
        yield return new WaitForSeconds(0.5f);
        IG.Moves.transform.DOLocalMoveY(-99.01001f, 0.7f);
        //IG.Lives.transform.DOLocalMoveY(-512.14f, 0.7f);
        yield return new WaitForSeconds(0.4f);
        IG.Settings.transform.DOLocalMoveX(-513.2f, 0.7f);
        yield return new WaitForSeconds(0.5f);
        GameOverObj.SetActive(true);
    }
}
