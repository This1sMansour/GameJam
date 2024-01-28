using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Score score;

    public void SetUp()
    {

        if (score.newHighScore)
        {
            PlayerPrefs.SetInt("highScore", score.highScore);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
