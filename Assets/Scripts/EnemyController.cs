using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Transform dest;
    [SerializeField] GameObject myRBObject;
    [SerializeField] GameObject myNavMeshObject;

    [Header("Parameters")]
    [SerializeField] float speed;
    [SerializeField] float bounceForce;
    [SerializeField] float stunned;
    private float timer;


    void Awake()
    {
        myNavMeshObject.gameObject.GetComponent<NavMeshAgent>().speed = speed;
        timer = stunned;
    }

    void Update()
    {
        // Si el componente esta "activado"
        if (myNavMeshObject.GetComponent<NavMeshAgent>().speed >= speed)
        {
            // Posicionamos el rigidbody e impedimos que se gire.
            myRBObject.transform.position = myNavMeshObject.transform.position + new Vector3(0, 1.2f, 0);
            myRBObject.GetComponent<Rigidbody>().freezeRotation = true;

            if (myNavMeshObject.GetComponent<NavMeshAgent>().isOnNavMesh)
            {
                if (GameManager.instance.isPowerUpActive())
                {
                    Vector3 posToRun = -(transform.position + dest.transform.position);
                    myNavMeshObject.GetComponent<NavMeshAgent>().SetDestination(posToRun);
                }
                else
                    myNavMeshObject.GetComponent<NavMeshAgent>().SetDestination(dest.position);
            }
        }
        else
        {
            //Movemos el objeto navmesh y la malla donde se dirija el rigidbody
            myNavMeshObject.transform.position = myRBObject.transform.position - new Vector3(0, 1.2f, 0);
            myRBObject.GetComponent<Rigidbody>().freezeRotation = false;
           
            // Temporizador para "reactivar" el NavMeshAgent
            if (timer < 0.0f)
            {
                myNavMeshObject.GetComponent<NavMeshAgent>().speed = speed;
                timer = stunned;
            }
            else timer -= Time.deltaTime;
        }        
    }

}
