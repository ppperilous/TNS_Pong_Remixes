using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Ball ball;
    private int _playerScore;
    private int _MissesScore;
    public TextMeshProUGUI HitscoreText;
    public TextMeshProUGUI MissScoreText;
    public int winningScore;
    private float timeinPlace;
    public Timer currentTime;
    
    

    void Start()
    {
        //Get time remaining value from timer script
      //  timeinPlace = GameObject.("TimeKeeper").GetComponent<Timer>();


    }
    void Update() {

      
    }
 
    
    //When ball hits RACKET update Hit text and check if endgame condition met
    public void HitUpdateScore(){
        _playerScore++;
       this.HitscoreText.text = "Hit: " + _playerScore.ToString();
        Debug.Log("Hits #: " + _playerScore + "/30");
        Debug.Log("Time now? " + Timer.currentTime);
        ResetRound();
    }

    //When ball hits WALL update Hit text and check if endgame condition met
    public void MissUpdateScore(){
        _MissesScore++;
        this.MissScoreText.text = "Miss: " + _MissesScore.ToString();
        Debug.Log("Miss #: " + _MissesScore);
        // ResetRound();
    }
    //Check and see if endgame conditions have been met
    public void ResetRound(){

        if (_playerScore == winningScore || Timer.currentTime <= 0 )
        {
            ApplicationData.FinalScore = _playerScore;
            ApplicationData.MissScore = _MissesScore;
            ApplicationData.EndTime = Timer.currentTime;
            SceneManager.LoadScene("EndScene");
            Debug.Log("final hits: " + ApplicationData.FinalScore);           

        }
    }
   

}

public static class ApplicationData
{
    public static float FinalScore;
    public static float MissScore;
    public static float EndTime;

}