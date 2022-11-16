using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    private ScoreKeeper scoreKeeper;
    
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        if (scoreKeeper.CalculateScore() >= 90)
        {
            finalScoreText.text = "You know your stuff. \n Final score: " + scoreKeeper.CalculateScore() + "%";
        }
        else if (scoreKeeper.CalculateScore() > 75 && scoreKeeper.CalculateScore() < 90)
        {
            finalScoreText.text = "Not bad. I guess. Not good either. \n Final score: " + scoreKeeper.CalculateScore() + "%";
        }
        else
        {
            finalScoreText.text = "Pathetic. Truly terrible. \n Final score: " + scoreKeeper.CalculateScore() + "%"; 
        }
    }
}
