using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Radio : MonoBehaviour
{
    public AudioMixer audioMixer;

    public List<RadioStation> radioStations;
    public int currentStation;

    public float waitBeforeOff = 15;

    public Image Radio_On;
    public Image Radio_Off;
    private bool OnOff;

    private float volume;


    // Start is called before the first frame update
    void Start()
    {
        OnOff = true;
        Radio_Off.gameObject.SetActive(false);
        Radio_On.gameObject.SetActive(true);

        PlayRadio();
    }

    

    public void AdjustRadioVolume(float value)
    {
        volume = value;
        if (OnOff) { audioMixer.SetFloat("Volume", value); }
    }

    public void PlayRadio()
    {
        for (int i = 0; i < radioStations.Count; i++)
        {
            if(i != currentStation)
            {
                radioStations[i].audioSource.volume = 0;
                radioStations[i].waitTime = waitBeforeOff;
                radioStations[i].currentRadio = false;
            }
        }
        radioStations[currentStation].audioSource.volume = 1;
        radioStations[currentStation].stopRadio = false;
        radioStations[currentStation].currentRadio = true;
    }


    public void NavigateStations(bool value)
    {
        // Navigate forwards
        if (value == true)
        {
            currentStation += 1;
            if (currentStation >= radioStations.Count)
            {
                currentStation = 0; 
            }
        }

        //Navigate backwards
        else
        {
            currentStation -= 1;
            if(currentStation < 0)
            {
                currentStation = radioStations.Count - 1;
            }
            
        }
        PlayRadio();
    }  

    public void OnClick()
    {
        OnOff = false;
        Radio_Off.gameObject.SetActive(true);
        Radio_On.gameObject.SetActive(false);

        audioMixer.SetFloat("Volume", -80f);
    }

    public void OffClick()
    {
        OnOff = true;
        Radio_Off.gameObject.SetActive(false);
        Radio_On.gameObject.SetActive(true);

        audioMixer.SetFloat("Volume", volume);
    }
}
