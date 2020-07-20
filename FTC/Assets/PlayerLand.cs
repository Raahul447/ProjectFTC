using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = true;
        }
    }
}
