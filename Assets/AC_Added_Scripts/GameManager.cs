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

    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitUpdateScore(){
        _playerScore++;
       this.HitscoreText.text = "Hit: " + _playerScore.ToString();
        Debug.Log("Hits #: " + _playerScore);
    }

   public void MissUpdateScore()
    {
        _MissesScore++;
        this.MissScoreText.text = "Miss: " + _MissesScore.ToString();
        Debug.Log("Miss #: " + _MissesScore);
    }

    private void ResetRound()
    {
        if (_playerScore == 3)
        {
            //newTrial();
            this.ball.ResetPosition(); //ball should stop moving once game is over
        }
    }


    }

