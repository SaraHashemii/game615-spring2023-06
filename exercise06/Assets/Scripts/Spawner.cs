using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    GameObject zombie;
    ZombieController ZC;
    bool stopInstantiate; 

    void Start()
    {
        zombie = Instantiate(prefab, transform.position, Quaternion.identity);
        ZC = zombie.GetComponent<ZombieController>();
        stopInstantiate = false;
    }

    public IEnumerator Instantiate()
    {
        stopInstantiate = true; 
        yield return new WaitForSeconds(5);
        zombie = Instantiate(prefab, transform.position, transform.rotation);
        ZC = zombie.GetComponent<ZombieController>(); 
    }

    private void Update()
    {
        if (ZC._asleep && !stopInstantiate)
        {
            StartCoroutine(Instantiate());          
        }
        if (!ZC._asleep)
        {
            stopInstantiate = false;
        }
    }

    public void LargeSpawn()
    {
        var spawnTime = 5;
        Invoke("Instantiate", spawnTime);
    }

}
