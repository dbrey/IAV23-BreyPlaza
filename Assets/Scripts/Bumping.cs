using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bumping : MonoBehaviour
{
    public Rigidbody myRB;
    public NavMeshAgent myNavMesh;
    public float bounceForce;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Character" || collision.gameObject.tag == "Player")
        {
            if(myNavMesh != null)
            {
                myNavMesh.enabled = false;
            }

            myRB.AddExplosionForce(bounceForce * 20, collision.contacts[0].point, 1.0f);
        }
        
    }
}
