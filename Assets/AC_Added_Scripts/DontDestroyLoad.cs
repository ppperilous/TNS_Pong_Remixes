using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DontDestroyLoad : MonoBehaviour
{
    // Start is called before the first frame update
    private float HitScore;
    public TextMeshProUGUI Final_Hits;
    private float MissScore;
    public TextMeshProUGUI Final_Misses;
    private float TimeRemaining;
    public TextMeshProUGUI Final_Time;
    public TextMeshProUGUI Export_Time;
    private float TimeLeft;
    void OnEnable()
    {
        HitScore = ApplicationData.FinalScore;
        MissScore = ApplicationData.MissScore;
        DisplayTime(ApplicationData.EndTime);

    }

    void Start()
    {
        this.Final_Hits.text = "" + HitScore;
        this.Final_Misses.text = "" + MissScore;
        this.Final_Time.text = Export_Time.text;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        Export_Time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
}
