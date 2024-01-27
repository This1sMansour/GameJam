using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        timerText.text=elapsedTime.ToString();
    }
}
