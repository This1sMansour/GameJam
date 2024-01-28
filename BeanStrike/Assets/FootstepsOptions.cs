using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsOptions : MonoBehaviour
{

    [HideInInspector]
    public AudioSource audioSource;

    public List<AudioClip> footstepClips;
    List<AudioClip> currentFootstepClips;

    public AudioClip currentClip;
    public int currentClipNumber;

    public bool currentFootstep;
    public bool stopFootstep;
    [HideInInspector]
    public float waitTime;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShuffleFootsteps();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFootstep != true && stopFootstep != true)
        {
            waitTime -= 1 * Time.deltaTime;
            if (waitTime <= 0)
            {
                audioSource.Stop();
                ShuffleFootsteps();
                stopFootstep = true;
            }
        }

        if (stopFootstep != true)
        {
            if (!audioSource.isPlaying)
            {
                currentClipNumber += 1;
                if (currentClipNumber >= footstepClips.Count)
                {
                    currentClipNumber = 0;
                }

                currentClip = currentFootstepClips[currentClipNumber];
                audioSource.clip = currentClip;
                audioSource.Play();
            }
        }


    }

    public void ShuffleFootsteps()
    {
        currentFootstepClips = footstepClips;
        List<int> numbersTaken = new List<int>();

        for (int i = 0; i < footstepClips.Count; i++)
        {
            bool next = false;
            while (next != true)
            {
                int newNumber = Random.Range(0, footstepClips.Count);
                if (numbersTaken.Contains(newNumber) != true)
                {
                    currentFootstepClips[i] = footstepClips[newNumber];
                    next = true;
                }
            }
        }


    }
}
