using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyLifeSystem : MonoBehaviour
{
    private void Awake()
    {
        int numPlayers = FindObjectsOfType<LifeSystem>().Length;
        if (numPlayers != 1)
        {
            Destroy(this.gameObject);
        }
        // if more then one player is in the scene
        //destroy ourselves
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
