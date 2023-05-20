using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void goToScene(string nameScene)
    {
        GameManager.instance.stopMusic();
        SceneManager.LoadScene(nameScene);
        GameManager.instance.chooseMusic(nameScene);
    }

    public void quitApp()
    { 
        Application.Quit(); 
    }
}
