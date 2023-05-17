using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void goToScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void quitApp()
    { 
        Application.Quit(); 
    }
}