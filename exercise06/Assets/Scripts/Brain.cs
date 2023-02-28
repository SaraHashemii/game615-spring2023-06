using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public GameObject area;
    //public GameObject area2;
    //public GameObject area3;
    //public GameObject area4;
    float xPosRight, xPosLeft, zPosUP, zPosDown;
    bool _canSpawn;
    GameObject brain;
    public GameObject brainPrefab;

    // Start is called before the first frame update
    void Start()
    {

        xPosRight = Random.Range(-22, -6);
        xPosLeft = Random.Range(6, 22);
        zPosUP = Random.Range(-32, -18);
        zPosDown = Random.Range(2, 16);
        Vector3 area1Vector = new Vector3(this.transform.position.x + xPosRight, this.transform.position.y, this.transform.position.z + zPosUP);
        brain = Instantiate(brainPrefab, area1Vector, transform.rotation);

    }

    public IEnumerator SpawnOneBrain()
    {

        //spawn a new brain
        _canSpawn = true;
        yield return new WaitForSeconds(5);
        Vector3 area1Vector = new Vector3(this.transform.position.x + xPosRight, this.transform.position.y, this.transform.position.z + zPosUP);
        brain = Instantiate(brainPrefab, area1Vector, transform.rotation);
    }
}
