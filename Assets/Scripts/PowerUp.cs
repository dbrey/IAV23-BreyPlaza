using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] float AddForce;
    [SerializeField] float tPowerUp;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Bumping>().bounceForce = AddForce;
            collision.gameObject.GetComponent<Bumping>().startTimer(tPowerUp);
            GameManager.instance.powerUpMusic();
            Destroy(this.gameObject);
        }
    }
}
