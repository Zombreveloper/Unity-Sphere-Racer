using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //private GameObject planet;
    //public PlanetSelection PlanetSelection;
    public int currentPlanet;

    public void updateCurrentPlanet(int planet)
    {
        currentPlanet = planet;
        Debug.Log(planet);
    }

    public void Play()
    {
        //SceneManager.LoadScene("Mars"); //Testzweck, besser abfrage was der spiler gewählt hat...

        //schlechter code: anzahl der Planeten variable, namen sollten dynamisch, nicht total sein
        if (currentPlanet == 0)
        {
            //SceneManager.LoadScene("Mond");
            Debug.Log("Lade Mond Szene");
        }
        else if (currentPlanet == 1)
        {
            SceneManager.LoadScene("Mars");
        }
        else if (currentPlanet == 2)
        {
            //SceneManager.LoadScene("Wasser");
            Debug.Log("Lade Wasser Szene");
        }
        else if (currentPlanet == 3)
        {
            //SceneManager.LoadScene("Bambus");
            Debug.Log("Lade Bambus Szene");
        }
    }

    public void Quit()
    {
        Debug.Log("QUIT!!!!!!");
        Application.Quit(); //spiel verlassen
    }
}
