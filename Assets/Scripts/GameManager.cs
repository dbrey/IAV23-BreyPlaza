using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject powerUp;
    private int nButtonsDown;
    private bool allPushed;
    bool gotPowerUp;

    [Header("Music")]
    [SerializeField] AudioClip menuClip;
    [SerializeField] AudioClip map1Clip;
    [SerializeField] AudioClip map2Clip;
    [SerializeField] AudioClip map3Clip;
    [SerializeField] AudioClip powerUpClip;
   
    AudioClip savedClip;
    AudioSource musica;

    public static GameManager instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            musica = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

    }

    private void Start()
    {
        chooseMusic(SceneManager.GetActiveScene().name);
        nButtonsDown = 0;
        gotPowerUp = false;
    }

    public void powerUpMusic()
    {
        gotPowerUp = true;
        musica.clip = powerUpClip;
        musica.Play();
    }

    public void returnToMusicLevel()
    {
        gotPowerUp = false;
        musica.clip = savedClip;
        musica.Play();
    }

    public void stopMusic()
    {
        musica.Stop();
    }

    public void chooseMusic(string nameScene)
    {
        switch (nameScene)
        {
            case "Map1":
                musica.clip = map1Clip;
                break;

            case "Map2":
                musica.clip = map2Clip;
                break;

            case "Map3":
                musica.clip = map3Clip;
                break;
            case "Menu":
            default:
                musica.clip = menuClip;
                break;
        }

        savedClip = musica.clip;
        musica.Play();
    }
    
    public void pushButton(Vector3 pos)
    {
        nButtonsDown++;
        if (nButtonsDown == 3)
        {
            nButtonsDown = 0;
            Instantiate(powerUp, pos, Quaternion.identity);

            allPushed = true;
        }
        else allPushed = false;
    }
    public bool getStatusButtons()
    {
        return allPushed;
    }

    public bool isPowerUpActive()
    {
        return gotPowerUp;
    }
    
}
