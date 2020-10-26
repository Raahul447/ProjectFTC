using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeleteData : MonoBehaviour
{
    
     
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("levelAt", 3);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
