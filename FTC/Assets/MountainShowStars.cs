using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MountainShowStars : MonoBehaviour
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
        for (int i = 6; i > 5 && i < 11; i++)
        {
            sum += PlayerPrefs.GetInt("Lv" + i.ToString());
        }
        text.text = sum + "/" + 15;
    }
}
