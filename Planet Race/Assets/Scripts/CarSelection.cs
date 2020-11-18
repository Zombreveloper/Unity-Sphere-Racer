﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour
{
    public GameObject[] cars; //Macht GameObject Planets zu einem Array
    public int selectedCar = 0; //index das Array

    public void NextCar()
    {
        cars[selectedCar].SetActive(false);
        selectedCar = (selectedCar + 1) % cars.Length;
        cars[selectedCar].SetActive(true);
    }

    public void PreviousCar()
    {
        cars[selectedCar].SetActive(false);
        selectedCar--;
        if (selectedCar < 0)
        {
            selectedCar += cars.Length;
        }
        cars[selectedCar].SetActive(true);
    }

    void StartGame() //von MainMenü rufen lassen
    {
        PlayerPrefs.SetInt("selectedCar", selectedCar); //speichert Daten, zwischen szenen
        //SceneManager.LoadScene("Mars", LoadSceneMode.Single);
    }
}
