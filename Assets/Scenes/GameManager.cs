using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    
    private int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update

    void Start()
    {
        score = 0;
        UpdateScore(0);
         
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "RacketLeft")
        {
            UpdateScore(1);
        }
        }
        public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text ="Score: " + score;
    }
}
