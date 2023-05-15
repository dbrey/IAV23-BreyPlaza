using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] Transform shootPoint;
    public float minShootForce;
    public float maxShootForce;
    public float timer;
    private float t;

    private void Start()
    {
        t = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (t < 0)
        {
            var instance = Instantiate(bomb, shootPoint.position, Quaternion.identity);
            instance.GetComponent<Rigidbody>().AddForce(shootPoint.transform.forward * Random.Range(minShootForce, maxShootForce));
            t = timer;
        }
        else
            t -= Time.deltaTime;
        
    }
}
