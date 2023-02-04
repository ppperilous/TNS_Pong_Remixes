using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Ball ball;

    public Text Missestext;

    private int _playerScore;
    private int _computerScore;

    private int score;
    public TextMeshProUGUI HitscoreText;

    public int trialNum;
    public string trialName;
    public List<string> trials;
    public int winningScore;


    // Start is called before the first frame update

    void Start()
    {
        _playerScore = 0;
        HitUpdateScore(0);
        trialNum = GlobalControl.Instance.trialNum;
        trialName = GlobalControl.Instance.trialName;
        trials = GlobalControl.Instance.trials;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
        void HitUpdateScore(int scoreToAdd)
    {
        _playerScore += scoreToAdd;
        HitscoreText.text = "Hits: " + _playerScore;
 
    }
}
