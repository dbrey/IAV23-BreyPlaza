using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballObstacle : MonoBehaviour
{
    [SerializeField] float rotateVel;
    [SerializeField] float maxRotate;
    [SerializeField] float maxTimer;
    [SerializeField] float minTimer;
    [SerializeField] bool rightSide;

    private bool rotateBack;
    private float ogRotate;
    private float currentRotate;
    private float t;

    void Start()
    {
        ogRotate = transform.eulerAngles.y;
        t = Random.Range(minTimer, maxTimer);
        rotateBack = false;
        currentRotate = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (t > 0)
        {
            t -= Time.deltaTime;
        }
        else
        {
            if (rightSide)
            {
                if (!rotateBack && currentRotate >= maxRotate)
                    rotateBack = true;
                else if(!rotateBack)
                {
                    // Como el transform.eulerAngles se reinicia si se pasa de los 360, guardamos su valor completo
                    currentRotate += Time.deltaTime * rotateVel;
                    transform.Rotate(0.0f, Time.deltaTime * rotateVel, 0.0f);
                }
                

                if (rotateBack && currentRotate >= ogRotate)
                {
                    currentRotate += Time.deltaTime * -(rotateVel / 6);
                    transform.Rotate(0.0f, Time.deltaTime * -(rotateVel / 6), 0.0f);
                }
                else if(rotateBack)
                {
                    t = Random.Range(minTimer, maxTimer);
                    rotateBack = false;
                }
            }
            else 
            {
                if (!rotateBack && currentRotate <= maxRotate)
                    rotateBack = true;
                else if (!rotateBack)
                {
                    // Como el transform.eulerAngles se reinicia si se pasa de los 360, guardamos su valor completo
                    currentRotate += Time.deltaTime * -rotateVel;
                    transform.Rotate(0.0f, Time.deltaTime * -rotateVel, 0.0f);
                }

                // Rotamos a la posicion original
                if (rotateBack && currentRotate <= ogRotate)
                {
                    currentRotate += Time.deltaTime * (rotateVel / 6);
                    transform.Rotate(0.0f, Time.deltaTime * (rotateVel / 6), 0.0f);
                }
                else if (rotateBack)
                {
                    // Si estamos en la posicion original, reiniciamos el temporizador
                    t = Random.Range(minTimer, maxTimer);
                    rotateBack = false;
                }
            }
        }

    }
}
