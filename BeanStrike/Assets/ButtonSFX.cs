using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource buttonSFX;
    public AudioClip hoverSFX;
    public AudioClip clickSFX;

    public void HoverSound()
    {
        buttonSFX.PlayOneShot(hoverSFX);
    }

    public void ClickSound()
    {
        buttonSFX.PlayOneShot(clickSFX);
    }

}
