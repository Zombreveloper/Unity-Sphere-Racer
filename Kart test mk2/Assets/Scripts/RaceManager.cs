using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public Transform playerCar;
    public Transform startPoint; //leres Object mit korrektem Transform für startendes Auto

    public Transform checkPointMesh; //Mesh bzw Modell vom aktiven Checkpoint
    private Transform parentOfCheckPoints; //Parent von allen Checkpoints, heißt "AllCheckPoints"
    private int numberOfCheckPoints;
    private int numberOfActive;
    private int checkPointLayer;
    public bool triggerStatus { get; set; }

//hauptprogramm
    void Awake()
    {
        setupCheckPoints();
        checkPointLayer = LayerMask.NameToLayer("CheckPoint");
    }

    void Start()
    {
        startRace();
        triggerStatus = true;
    }

    void Update()
    {
        //setzt Mesh auf naechste Checkpoints
        updateCheckPoints();
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
        numberOfActive = numberOfCheckPoints; //startwert, collider der Ziellinie
    }

    void startRace()
    {
        //setzt Auto an StartOrt
        playerCar.position = startPoint.position;
        playerCar.rotation = startPoint.rotation;

        //Startet counter (3, 2, 1, GO!)

        //Startet anschliessend Musik

        //setzt ersten CheckPoint
    }

    void updateCheckPoints()
    {
        if (triggerStatus)
        {
            if (numberOfActive == numberOfCheckPoints)
            {
                numberOfActive = 0;
                positionMesh(numberOfActive);
            }
            else
            {
                numberOfActive++;
                positionMesh(numberOfActive);
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
}
