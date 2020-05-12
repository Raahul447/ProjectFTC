using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public string levelName;

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
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(NextLevelLoad());
            Debug.Log("POP");
        }
    }

    IEnumerator NextLevelLoad()
    {
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = false;
        GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>().SetTrigger("Next");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(levelName);
    }
}
