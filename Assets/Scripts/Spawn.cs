using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour
{
    [SerializeField] Transform spawnPos;
    [SerializeField] UIManager ui;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Character")
        {
            if(spawnPos != null)
            {
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

                collision.gameObject.transform.position = spawnPos.position;
                rb.velocity = Vector3.zero;

                if (collision.gameObject.tag == "Character")
                {

                    // Accedemos al otro hijo, que tiene el navmeshagent
                    GameObject navmeshObject = collision.gameObject.transform.parent.gameObject;
                    navmeshObject.GetComponent<EnemyController>().resetEnemy();
                    if (ui != null)
                        ui.ActualizarEnemy();
                }
                else
                    ui.ActualizarJugador();
            }
            else
                Destroy(collision.gameObject.transform.parent.gameObject);
        }
        else
            Destroy(collision.gameObject);
    }
}
