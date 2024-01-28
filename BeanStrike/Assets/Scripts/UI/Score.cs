using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int highScore;
    public bool newHighScore;

    void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
        { highScore = PlayerPrefs.GetInt("highScore"); } 
        else 
        {
            highScore = 0; 
            PlayerPrefs.SetInt("highScore", 0);
            highScoreText.text = "High Score: 0";
        }
        newHighScore = false;
        
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + gameManager.score.ToString();

        if (highScore > gameManager.score)
        {
            newHighScore |= true;
            highScore = gameManager.score;
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}
