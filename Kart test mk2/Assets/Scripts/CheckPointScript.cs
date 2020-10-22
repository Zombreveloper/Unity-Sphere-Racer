using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public Transform RaceManager;
    private RaceManager _manager;

    void Awake()
    {
        _manager = GameObject.FindObjectOfType<RaceManager>();
    }

    void OnTriggerEnter()
    {
        //Debug.Log("on trigger enter CheckPointScrpt");

        _manager.triggerStatus = true;
    }
}
