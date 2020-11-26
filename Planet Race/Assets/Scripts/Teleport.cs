using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	public Transform teleportTarget; //Teleport Position
	private GameObject thePlayer; //Spieler, der teleportiert wird

    void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }

	// Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("carClone");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
