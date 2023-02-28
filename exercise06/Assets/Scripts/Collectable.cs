using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //UI changes
            //create particle
            Destroy(this.gameObject, 0.2f); 
        }

        if(other.gameObject.tag == "Enemy")
        {
            //UI changes
            //create particle
            Destroy(this.gameObject, 0.2f);
        }
    }
}
