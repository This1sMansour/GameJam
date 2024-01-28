using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1 Safe Copy");
    }

    public void ShowSettings()
    {
        settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
