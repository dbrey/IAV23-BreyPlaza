using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Follow : MonoBehaviour
{

    Vector3 offset;
    [SerializeField] Transform player;

    void Start()
    {
        offset = player.position - transform.position;
    }

    void Update()
    {
        transform.position = player.position - offset;
    }
}
