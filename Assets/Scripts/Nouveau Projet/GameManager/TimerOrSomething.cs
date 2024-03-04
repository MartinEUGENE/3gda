using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TimerOrSomething : MonoBehaviour
{
    public Text timeTohaveText;
    public float timeToGo = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        timeToGo += Time.deltaTime;
        DisplayTime(timeToGo);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeTohaveText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
