﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public GameObject playerCar;
    private Rigidbody playerCarRB;
    public Transform startPoint; //leres Object mit korrektem Transform für startendes Auto

    private string planetImOn;

    public LoadCar _loadCar;

    public Transform checkPointMesh; //Mesh bzw Modell vom aktiven Checkpoint
    private Transform parentOfCheckPoints; //Parent von allen Checkpoints, heißt "AllCheckPoints"
    private int numberOfCheckPoints;
    private int numberOfActive; //Nummer in RaceManager
    public int nameOfActive; //Name der Objecte der CheckPointScricpts
    private int numberOfResetPos; //letzter von Auto durchfahrener Checkpoint
    private int checkPointLayer;
    public bool triggerStatus { get; set; }

    private float startingTime;
    private float endingTime;

//hauptprogramm
    void Awake()
    {
        setupCheckPoints();
        checkPointLayer = LayerMask.NameToLayer("CheckPoint");
        planetImOn = PlayerPrefs.GetString("selectedPlanet");
    }

    void Start()
    {
        startRace();
        triggerStatus = false;

        playerCar = GameObject.Find("currentCar");
        playerCarRB =playerCar.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //setzt Mesh auf naechste Checkpoints
        updateCheckPoints();

        if (Input.GetKeyDown(KeyCode.R))
        {
            resetCar();
        }
    }

/*
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != checkPointLayer)
        {
            return;
        }
        else
        {
            triggerStatus = true;
            Debug.Log("enter Trigger RaceManager");
        }
    }
*/

//methoden
    void setupCheckPoints()
    {
        parentOfCheckPoints = GameObject.Find("AllCheckPoints").transform;
        numberOfCheckPoints = parentOfCheckPoints.childCount;
        numberOfActive = 0; //startwert, collider der Ziellinie
        numberOfResetPos = 0;
    }

    void startRace()
    {
        positionMesh(numberOfActive);

        //setzt Auto an StartOrt
        /*playerCar.position = startPoint.position;
        playerCar.rotation = startPoint.rotation;*/

        //Startet counter (3, 2, 1, GO!)

        //Nach GO! startzeit nehmen
        startingTime = Time.time;

        //Startet anschliessend Musik
    }

    void updateCheckPoints()
    {
        if (triggerStatus)
        {
            //Debug.Log("nameOfActive = " + nameOfActive);
            //Debug.Log("numberOfActive = " + numberOfActive);
            if (nameOfActive == numberOfActive)
            {
                if (numberOfActive == numberOfCheckPoints-1)
                {
                    numberOfResetPos = numberOfActive;
                    numberOfActive = 0;
                    positionMesh(numberOfActive);
                }
                else
                {
                    numberOfResetPos = numberOfActive;
                    numberOfActive++;
                    positionMesh(numberOfActive);
                }
            }
        }
        //bei Trigger numberOfActive++; + positionMesh();
    }

    void positionMesh(int numberOfPoint)
    {
        //transform holen
        Transform posOfPoint = parentOfCheckPoints.transform.GetChild (numberOfPoint); //0 bis childCount

        checkPointMesh.position = posOfPoint.position;
        checkPointMesh.rotation = posOfPoint.rotation;
        triggerStatus = false;
    }

    public void resetCar()
    {
        playerCarRB.velocity = Vector3.zero; //geschwindigkeit auf 0 setzen
        Transform posOfPoint = parentOfCheckPoints.transform.GetChild (numberOfResetPos); //transform des letzten checkpoints holen
        playerCar.transform.position = posOfPoint.position + new Vector3(0,4,0);
        //nich += denn es soll insgesamt auch bei mehrmaligem drücken nur eimal (1) 3 aud die höhe addiert werden

        //weil die CheckPoints alle in unterschiedliche Richtungen gucken... unterschiedliche rotation am ziel
        if (planetImOn == "Mars")
        {
            playerCar.transform.rotation = posOfPoint.rotation * Quaternion.Euler(0, 90, 0); // this adds a 90 degrees Y rotation
        }
        else if (planetImOn == "Mond")
        {
            playerCar.transform.rotation = posOfPoint.rotation * Quaternion.Euler(0, -90, 0);
        }
        else if (planetImOn == "Bambus")
        {
            playerCar.transform.rotation = posOfPoint.rotation * Quaternion.Euler(0, 0, 0);
        }
        else if (planetImOn == "BigBlueOcean")
        {
            playerCar.transform.rotation = posOfPoint.rotation * Quaternion.Euler(0, 0, 0);
        }

        //Debug.Log("Reset the Car NOW!!!");
    }
}
