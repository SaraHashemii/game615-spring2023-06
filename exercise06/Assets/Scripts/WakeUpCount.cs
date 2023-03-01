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
        if(timeCount != 0)
        {
            DisplayTime(timeCount);
        }
        else
        {
            timeCount = 0; 
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay -= 1;
        float seconds = Mathf.FloorToInt(timeCount % 60);
        timer.text = string.Format("{00}", seconds);
    }
}
