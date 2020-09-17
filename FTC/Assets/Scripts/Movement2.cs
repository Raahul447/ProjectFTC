using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{

    public Movement Mv;
    public CubesTypes Ct;
    public LifeSystem Ls;
    public HeartsSystem Hs;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Hs = GameObject.Find("HeartsLives").GetComponent<HeartsSystem>();
        Ls = GameObject.Find("Life System").GetComponent<LifeSystem>();
        Mv = GameObject.Find("Player").GetComponent<Movement>();
        Ct = GameObject.Find("FinalCube").GetComponent<CubesTypes>();
        Ls.lives--;

        if(Ls.lives == 2)
        {
            Hs.TwoLivesRemove();
        }
        else if(Ls.lives == 1)
        {
            Hs.OneLivesRemove();
        }
        else if(Ls.lives == 0)
        {
            Hs.ZeroLivesRemove();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
