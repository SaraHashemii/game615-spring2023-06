using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private ZombieController ZC;
    
    private void Awake()
    {
        ZC = GetComponentInParent<ZombieController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            ZC._agent.destination = other.transform.position;
            ZC.inRange = true;
        }
    }
}
