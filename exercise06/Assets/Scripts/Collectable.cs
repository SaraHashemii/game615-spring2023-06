using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //public bool isDestroyed;
    //public GameObject particleEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //UI changes
            //create particle
           // Instantiate(particleEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);

            Destroy(this.gameObject);
            //isDestroyed = true;
        }

        if(other.gameObject.tag == "Enemy")
        {
            //UI changes
            //create particle
            Destroy(this.gameObject, 0.2f);
            //isDestroyed = true;
        }
    }
}
