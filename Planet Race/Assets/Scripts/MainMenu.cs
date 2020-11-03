using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Mars"); //Testzweck, besser abfrage was der spiler gewählt hat...
    }

    public void Quit()
    {
        Debug.Log("QUIT!!!!!!");
        Application.Quit(); //spiel verlassen
    }
}
