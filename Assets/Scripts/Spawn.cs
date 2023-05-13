using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Transform spawnPos;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = spawnPos.position;
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else
            Destroy(collision.gameObject.transform.parent.gameObject);
    }
}
