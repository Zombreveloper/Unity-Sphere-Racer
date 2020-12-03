using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public Transform RaceManager;
    private RaceManager _manager;
    private string myName;

    void Awake()
    {
        _manager = GameObject.FindObjectOfType<RaceManager>();
        myName = this.name;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("on trigger enter CheckPointScrpt");

        _manager.triggerStatus = true;
        _manager.nameOfActive = int.Parse(myName);
    }
}
