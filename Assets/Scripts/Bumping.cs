using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bumping : MonoBehaviour
{
    public NavMeshAgent myNavMesh;
    public float bounceForce;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Character" || collision.gameObject.tag == "Player")
        {
            if(myNavMesh != null)
            {
                myNavMesh.speed = 0;
            }

            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(bounceForce * 20, collision.contacts[0].point, 1.0f);
        }
        
    }
}
