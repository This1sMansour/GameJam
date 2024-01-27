using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] backgroundMusicArray;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;

        if (backgroundMusicArray.Length != 0)
        {
            StartCoroutine(PlayRandomMusic());
        }
    }

    IEnumerator PlayRandomMusic()
    {
        while (true)
        {
            var randomClip = backgroundMusicArray[Random.Range(0, backgroundMusicArray.Length)];
            audioSource.clip = randomClip;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
    }
}