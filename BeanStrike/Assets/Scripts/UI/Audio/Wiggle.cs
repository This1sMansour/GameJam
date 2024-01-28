using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Wiggle : MonoBehaviour

{

    public AudioSource wiggleSound;
    public AudioClip wiggleSFX;



    void Update()

    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {

            wiggleSound.enabled = true;
     


        }


    }

  

    



}