﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyPlanetGravitation : MonoBehaviour
{
    public Rigidbody rbToAttract;
    public Transform tinyPlanet;
    public float MassOfTinyPlanet = 100000f;

    Vector3 directionOfGravity;
    public float gravity = 30f;
    private float forceOfGravity;
    private float distance;

    void start()
    {
        //holt sich Rigidbody von Objekt an dem es dranhaengt
        //tinyPlanet = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //forceOfGravity muss in richtung directionOfGravity auf objToAttract uebertragen werden.

        //folgender code funktioniert, ist aber bullshit
        //rbToAttract.AddForce(directionOfGravity.normalized * gravity);

        directionOfGravity = tinyPlanet.position - rbToAttract.position;
        distance = directionOfGravity.magnitude;

        //F=G*(m1*m2)/r^2 ->G=9.81, m1(Masse der Erde)=
        forceOfGravity = gravity * ((MassOfTinyPlanet * rbToAttract.mass)/Mathf.Pow(distance, 2));
        rbToAttract.AddForce(directionOfGravity.normalized * forceOfGravity);
    }
}
