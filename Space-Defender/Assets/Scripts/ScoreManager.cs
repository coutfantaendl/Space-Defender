using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public static ScoreManager Instance;

    private int score = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateScoreTextReference();
    }
    
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void UpdateScoreTextReference()
    {
        scoreText = GameObject.Find("ScoreText")?.GetComponent<Text>();

        if (scoreText != null)
        {
            UpdateScoreText();
        }
        
    }  
}
