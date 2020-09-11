using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CubePillarEffect : MonoBehaviour
{
    [Header("Values")]
    public GameObject[] Cubes;
    public float timer;
    public float[] y_Value;

    [Header("Player")]
    public GameObject Player;
    public float spawn_Timer;
    public Movement MV;

    // Start is called before the first frame update
    void Start()
    {
        //Cube = this.gameObject;
        //StartCoroutine(CubeMove());
        //MV.enabled = false;

        foreach (GameObject cube in Cubes)
        {
            foreach(float pillarValue in y_Value)
            {
                cube.transform.DOLocalMoveY(pillarValue, timer);
                timer += 0.1f;
            }

        }
        //StartCoroutine(SpawnPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(spawn_Timer);
        Player.transform.DOScale(2, 0.3f);
        yield return new WaitForSeconds(0.5f);
        MV.enabled = true;
    }
}
