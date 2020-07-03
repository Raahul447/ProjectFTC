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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DisableMovement());
    }

    IEnumerator DisableMovement()
    {
        yield return new WaitForSeconds(.1f);
        playerCube.GetComponent<Movement>().enabled = false;
        playerCube.GetComponent<Rigidbody>().isKinematic = false;
        yield return true;
    }
}
