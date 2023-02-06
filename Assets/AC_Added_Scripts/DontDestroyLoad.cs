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
    void OnEnable()
    {
        HitScore = ApplicationData.FinalScore;
        MissScore = ApplicationData.MissScore;
       // TimeRemaining = ApplicationData.EndTime;

    }

    void Start()
    {
        this.Final_Hits.text = "" + HitScore;
        this.Final_Misses.text = "" + MissScore;
     //   this.Final_Time.text = ApplicationData.EndTime.text;

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
