using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public string levelName;
    public GameObject tutorialCube;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "End Cube")
        {
            StartCoroutine(NextLevelLoad());
        }
    }

    IEnumerator NextLevelLoad()
    {
        yield return new WaitForSeconds(1f);
        tutorialCube.GetComponent<TutorialMovement>().enabled = false;
        GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>().SetTrigger("Next");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(levelName);
    }
}