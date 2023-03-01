using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class WakeUpCount : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float timeCount;

    void Start()
    {
        timeCount = 21; 
    }


    void Update()
    {
        timeCount -= Time.deltaTime;
        int seconds = (int)(timeCount % 60);
        timer.text = timeCount.ToString(); 
        if(timeCount == 0)
        {
            timeCount = 0; 
        }
    }
}
