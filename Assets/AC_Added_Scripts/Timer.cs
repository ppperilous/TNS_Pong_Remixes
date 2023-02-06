using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float timeRemaining = 50;
    public bool timerIsRunning = false;
    public TextMeshProUGUI TimeLeft;
    public GameManager ResetRound;
    public float currentTime;
       private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        // Grab access to GameManager in order to call ResetRound() function
        ResetRound = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                ResetRound.ResetRound();
            }
        }
    }
    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TimeLeft.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}