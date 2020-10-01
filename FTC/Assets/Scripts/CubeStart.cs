using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CubeStart : MonoBehaviour
{
    public GameObject cube;
    public TutorialMovement TM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scaleSpawn()
    {
        cube.transform.DOScale(new Vector3(2, 2, 2), 0.5f);
        TM.enabled = true;
    }
}
