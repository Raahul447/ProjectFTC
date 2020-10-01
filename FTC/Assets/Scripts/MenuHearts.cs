using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class MenuHearts : MonoBehaviour
{

    public TextMeshProUGUI Lives;
    public string LivesMenu;
    public LifeSystem Ls;

    // Start is called before the first frame update
    void Start()
    {
        Ls = GameObject.FindGameObjectWithTag("LifeSystem").GetComponent<LifeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        LivesMenu = Ls.currentLives.ToString();
        Lives.text = "x" + LivesMenu;
    }
}
