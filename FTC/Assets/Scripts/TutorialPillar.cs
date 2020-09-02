using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TutorialPillar : MonoBehaviour
{
    public GameObject pillar;
    public float x, y, z;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        pillar.transform.DOMove(new Vector3(x, y, z), time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
