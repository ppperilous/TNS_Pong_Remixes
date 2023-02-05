using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Ball ball;

   // public Text MissesText;
   // public Text HitsText;

    private int _playerScore;
    private int _MissesScore;

    public TextMeshProUGUI HitscoreText;
    public TextMeshProUGUI MissScoreText;
    public Timer timeRemaining;

    // public int trialNum;
    //  public string trialName;
    // public List<string> trials;
    public int winningScore;


    // Start is called before the first frame update

    void Start()
    {

        //  trialNum = GlobalControl.Instance.trialNum;
        //  trialName = GlobalControl.Instance.trialName;
        //  trials = GlobalControl.Instance.trials;
        timeRemaining = GameObject.Find("Timer").GetComponent<Timer>();
   
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitUpdateScore(){
        _playerScore++;
       this.HitscoreText.text = "Hit: " + _playerScore.ToString();
        Debug.Log("Hits #: " + _playerScore + "/30");
        ResetRound();
    }

   public void MissUpdateScore()
    {
        _MissesScore++;
        this.MissScoreText.text = "Miss: " + _MissesScore.ToString();
        Debug.Log("Miss #: " + _MissesScore);
        ResetRound();
    }

    public void ResetRound(){
        if (_playerScore == 3 || timeRemaining.timeRemaining == 0)
        {
            SceneManager.LoadScene("EndScene");
            //newTrial();
            
        }
    }


    }

