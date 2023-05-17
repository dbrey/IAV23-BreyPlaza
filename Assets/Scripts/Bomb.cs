using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb : MonoBehaviour
{
    public float bounceForce;
    public float timer;

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si choca con un personaje, accedemos a su NavMeshAgent y lo "desactivamos", añadimos una fuerza repulsiva explosiva y destruimos la bomba
        if (collision.gameObject.tag == "Character")
        {
            NavMeshAgent nvEnemy = collision.gameObject.transform.parent.Find("EnemyNavMesh").GetComponent<NavMeshAgent>();
            nvEnemy.speed = 0;
            

            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(bounceForce * 20, collision.contacts[0].point, 1.0f);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(bounceForce * 20, collision.contacts[0].point, 1.0f);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Bomb")
        {
            Destroy(this.gameObject);
        }
    }
}
