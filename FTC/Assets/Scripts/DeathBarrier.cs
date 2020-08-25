using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    [SerializeField]
    private GameObject playerCube;

    // Start is called before the first frame update
    void Start()
    {
        playerCube = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DisableMovement());
    }

    IEnumerator DisableMovement()
    {
        yield return new WaitForSeconds(.1f);
        playerCube.GetComponent<BoxCollider>().enabled = false;
        playerCube.GetComponent<Movement>().enabled = false;
        playerCube.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(1f);
        playerCube.GetComponent<BoxCollider>().enabled = true;
    }
}
