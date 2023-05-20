using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bumping : MonoBehaviour
{
    public NavMeshAgent myNavMesh;
    public float bounceForce;
    private float normalBounceForce;
    private float timer;

    private void Start()
    {
        normalBounceForce = bounceForce;
    }

    private void Update()
    {
        if(bounceForce > normalBounceForce)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
            {
                bounceForce = normalBounceForce;
                GameManager.instance.returnToMusicLevel();
            }
                
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si chocamos con un personaje o el jugador, añadimos una fuerza de empuje al otro
        if (collision.gameObject.tag == "Character" || collision.gameObject.tag == "Player")
        {
            if(myNavMesh != null)
            {
                myNavMesh.speed = 0;
            }

            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(bounceForce * 20, collision.contacts[0].point, 1.0f);
        }
        
    }

    public void startTimer(float t)
    {
        timer = t;
    }
}
