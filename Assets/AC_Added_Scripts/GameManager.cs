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
    public Timer timeRemaining;
    public Timer timeinPlace;

    void Start()
    {
        //Get time remaining value from timer script
        timeinPlace = GameObject.Find("Timer").GetComponent<Timer>();

    }
    void Update() {

        if (Input.GetKeyDown("0"))
        {
            SceneManager.LoadScene("EndScene");
            ApplicationData.FinalScore = _playerScore;
            ApplicationData.MissScore = _MissesScore;
            ApplicationData.EndTime.text = "Time: " + timeinPlace.timeRemaining;
        }
    }
    
    //When ball hits RACKET update Hit text and check if endgame condition met
    public void HitUpdateScore(){
        _playerScore++;
       this.HitscoreText.text = "Hit: " + _playerScore.ToString();
        Debug.Log("Hits #: " + _playerScore + "/30");
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
        if (_playerScore == 30 || timeinPlace.timeRemaining == 0 || _MissesScore == 30)
        {
            SceneManager.LoadScene("EndScene");
            ApplicationData.FinalScore = _playerScore;
            ApplicationData.MissScore = _MissesScore;
            ApplicationData.EndTime.text = "Time: " + timeinPlace.timeRemaining;
            Debug.Log("final hits: " + ApplicationData.FinalScore);

           

        }
    }
   

}

public static class ApplicationData
{
    public static float FinalScore;
    public static float MissScore;
    public static TextMeshProUGUI EndTime;

}