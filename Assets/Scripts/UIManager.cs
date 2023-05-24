using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text textEnemy;
    [SerializeField] TMP_Text textPlayer;

    private int enemyKOd;
    private int playerKOd;

    // Start is called before the first frame update
    void Start()
    {
        enemyKOd = playerKOd = 0;
        textEnemy.text = "Noqueos Enemigos : " + enemyKOd;
        textPlayer.text = "Noqueos Jugador : " + playerKOd;
    }

    public void ActualizarEnemy()
    {
        enemyKOd++;
        textEnemy.text = "Noqueos Enemigos : " + enemyKOd;
    }

    public void ActualizarJugador()
    {
        playerKOd++;
        textPlayer.text = "Noqueos Jugador : " + playerKOd;
    }

}
