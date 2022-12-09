
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Thanks to gamedev.tv for help with starting this scripting.
    
    private Quiz quiz;
    private EndScreen endScreen;
    private StartScreen startScreen;
    private Timer timer;

    [SerializeField] private AudioClip startSound;

    private void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
        startScreen = FindObjectOfType<StartScreen>();
        timer = FindObjectOfType<Timer>();
    }

    public void StartGame()
    {
        startScreen.gameObject.SetActive(false);
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(startSound);
    }
    
    void Update()
    {
        if (quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.ShowFinalScore();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
