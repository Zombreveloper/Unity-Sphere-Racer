using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public Transform playerCar;
    public Transform startPoint; //leres Object mit korrektem Transform für startendes Auto

    public LoadCar _loadCar;

    public Transform checkPointMesh; //Mesh bzw Modell vom aktiven Checkpoint
    private Transform parentOfCheckPoints; //Parent von allen Checkpoints, heißt "AllCheckPoints"
    private int numberOfCheckPoints;
    private int numberOfActive; //Nummer in RaceManager
    public int nameOfActive; //Name der Objecte der CheckPointScricpts
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
        triggerStatus = false;
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
        numberOfActive = 0; //startwert, collider der Ziellinie
    }

    void startRace()
    {
        positionMesh(numberOfActive);

        //setzt Auto an StartOrt
        /*playerCar.position = startPoint.position;
        playerCar.rotation = startPoint.rotation;*/

        //Startet counter (3, 2, 1, GO!)

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
                    numberOfActive = 0;
                    positionMesh(numberOfActive);
                }
                else
                {
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
}
