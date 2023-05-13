using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] Transform dest;
    [SerializeField] GameObject myRBObject;
    [SerializeField] GameObject myNavMeshObject;

    public float bounceForce;
    public float stunned;
    private float timer;



    // Start is called before the first frame update
    void Awake()
    {
        timer = stunned;
    }

    // Update is called once per frame
    void Update()
    {

        if (myNavMeshObject.GetComponent<NavMeshAgent>().enabled)
        {


            // Posicionamos el rigidbody e impedimos que se gire.
            myRBObject.transform.position = myNavMeshObject.transform.position + new Vector3(0, 1.2f, 0);
            myRBObject.GetComponent<Rigidbody>().freezeRotation = true;
            
            if(myNavMeshObject.GetComponent<NavMeshAgent>().isOnNavMesh)
                myNavMeshObject.GetComponent<NavMeshAgent>().SetDestination(dest.position);
        }
        else
        {
            //Movemos el objeto navmesh y la malla donde se dirija el rigidbody
            myNavMeshObject.transform.position = myRBObject.transform.position - new Vector3(0, 1.2f, 0);
            myRBObject.GetComponent<Rigidbody>().freezeRotation = false;
            //transform.position = myNavMeshObject.transform.position;
           
            if (timer < 0.0f)
            {
                myNavMeshObject.GetComponent<NavMeshAgent>().enabled = true;
                timer = stunned;
            }
            else timer -= Time.deltaTime;
        }        
    }

}
