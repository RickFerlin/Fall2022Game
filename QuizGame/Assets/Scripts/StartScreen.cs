
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private GameManager gameManager;
    private Quiz quiz;
    private EndScreen endScreen;
    private StartScreen startScreen;
    private Timer timer;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
        startScreen = FindObjectOfType<StartScreen>();
        timer = FindObjectOfType<Timer>();
    }

    private void Start()
    {
        startScreen.gameObject.SetActive(true);
        quiz.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
    }
}
