using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    public GameObject EndGameMenu;
    public EndGame endGame;

    void Start() 
    {
        remainingTime = 180;
    }


    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 20)
        {
            timerText.color = Color.red;

            if(remainingTime < 0) 
            {
                Debug.Log("End");
                EndGameMenu.SetActive(true);
                endGame.SetUp();
                remainingTime = 0;
            }
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
