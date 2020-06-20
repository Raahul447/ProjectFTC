using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCal : MonoBehaviour
{
    [Header("Moves")]
    public int currentMoves;
    public int maxMoves;

    [Header("Stars")]
    public int star1;
    public int star2;
    public int star3;

    public Movement tm;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentMoves = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentMoves == star1)
        {
            anim.SetTrigger("1s");
            //Debug.Log("Low Score");
        }
        else if(currentMoves == star2)
        {
            anim.SetTrigger("2s");
            //Debug.Log("Medium Score");
        }
        else if(currentMoves == star3)
        {
            anim.SetTrigger("3s");
            Debug.Log("High Score");
        }
        else if(currentMoves == maxMoves)
        {
            tm.enabled = false;
        }
    }
}
