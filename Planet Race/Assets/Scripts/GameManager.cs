using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Designpattern: Singleton (Eigentlich nicht nutzen...)

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public InputController InputController { get; private set; }

    void Awake()
    {
        Instance = this;
        //Singleton, andere können "Instance" jetzt über diese stativ-Variable finden
        // nur ein (1) GameManager möglich zu verbinde -> Listener-Pattern?!
        InputController = GetComponentInChildren<InputController>();
    }

    void Update()
    {

    }

}
