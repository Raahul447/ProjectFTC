using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FillBar : MonoBehaviour
{

    public LifeSystem lifesystem;
    public Image fillbar;
    public float variable;

    // Start is called before the first frame update
    void Start()
    {
        lifesystem = GameObject.Find("Life System").GetComponent<LifeSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        variable = (float)lifesystem.timerForLife;
        fillbar.fillAmount = variable/20;
    }
}
