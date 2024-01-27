using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public bool gamePasused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        // Show pause menu
        gameMenu.SetActive(!gameMenu.active);
        pauseMenu.SetActive(!pauseMenu.active);


        // Freeze time
        gamePasused = !gamePasused;
        Time.timeScale = gamePasused ? 0f : 1f; ;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
