using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!videoPlayer.isPlaying)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
