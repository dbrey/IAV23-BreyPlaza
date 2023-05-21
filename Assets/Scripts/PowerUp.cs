using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] float AddForce;
    [SerializeField] float tPowerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Bumping>().bounceForce = AddForce;
            other.gameObject.GetComponent<Bumping>().startTimer(tPowerUp);
            GameManager.instance.powerUpMusic();
            Destroy(this.gameObject);
        }
    }

}
