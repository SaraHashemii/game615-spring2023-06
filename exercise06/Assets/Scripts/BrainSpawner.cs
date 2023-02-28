using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainSpawner : MonoBehaviour
{
    Collectable collectable;

    GameObject brain;
    public GameObject brainPrefab;

    public GameObject area1;
    public GameObject area2;
    public GameObject area3;
    public GameObject area4;
    float xPosRight, xPosLeft, zPosUP, zPosDown;
    bool _canSpawn;

    // Start is called before the first frame update
    void Start()
    {

        xPosRight = Random.Range(-22, -6);
        xPosLeft = Random.Range(6, 22);
        zPosUP = Random.Range(-32, -18);
        zPosDown = Random.Range(2, 16);

    }

    // Update is called once per frame
    void Update()
    {
        //if (!_canSpawn)
        //{
        //    StartCoroutine(Instantiate());
        //}


    }


    //public IEnumerator Instantiate()
    //{
        

    //    if (collectable.isDestroyed)
    //    {
    //        _canSpawn = true;
    //        yield return new WaitForSeconds(30);
    //        Vector3 area1Vector = new Vector3(area1.transform.position.x + xPosRight, area1.transform.position.y, area1.transform.position.z + zPosUP);
    //        brain = Instantiate(brainPrefab, area1Vector, transform.rotation);
    //    }


    //    if (collectable.isDestroyed)
    //    {
    //        _canSpawn = true;
    //        yield return new WaitForSeconds(30);
    //        Vector3 area2Vector = new Vector3(area2.transform.position.x + xPosLeft, area2.transform.position.y, area2.transform.position.z + zPosUP);
    //        brain = Instantiate(brainPrefab, area2Vector, transform.rotation);
    //    }


    //    if (collectable.isDestroyed)
    //    {
    //        _canSpawn = true;
    //        yield return new WaitForSeconds(30);
    //        Vector3 area3Vector = new Vector3(area3.transform.position.x + xPosRight, area3.transform.position.y, area3.transform.position.z + zPosDown);
    //        brain = Instantiate(brainPrefab, area3Vector, transform.rotation);
    //    }


    //    if (collectable.isDestroyed)
    //    {
    //        _canSpawn = true;
    //        yield return new WaitForSeconds(30);
    //        Vector3 area4Vector = new Vector3(area4.transform.position.x + xPosLeft, area4.transform.position.y, area4.transform.position.z + zPosDown);
    //        brain = Instantiate(brainPrefab, area4Vector, transform.rotation);
    //    }

    //}
}
