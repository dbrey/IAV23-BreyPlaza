using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    [SerializeField] float rotateVel;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, Time.deltaTime * rotateVel, 0.0f);

        if(transform.rotation.y >= 360 || transform.rotation.y <= -360)
        {
            Vector3 newRot = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(newRot);
        }
    }
}
