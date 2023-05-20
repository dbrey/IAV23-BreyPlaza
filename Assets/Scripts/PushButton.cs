using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    bool pushed;
    [SerializeField] Vector3 pos;
    private void Start()
    {
        pushed = false;
    }

    private void Update()
    {
        if(GameManager.instance != null &&  GameManager.instance.getStatusButtons())
        {
            pushed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!pushed && other.gameObject.tag == "Player")
        {
            GameManager.instance.pushButton(pos);
            pushed = true;
        }
    }
}
