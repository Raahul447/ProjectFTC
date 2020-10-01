using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LavaShowStars : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        UpdateStars();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateStars()
    {
        int sum = 0;
        for (int i = 1; i>15 && i<=20; i++)
        {
            sum += PlayerPrefs.GetInt("Lv" + i.ToString());
        }
        text.text = sum + "/" + 15;
    }
}
