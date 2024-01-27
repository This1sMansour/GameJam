using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.position.x.ToString();
        //Debug.Log(player.position.x);
    }
}
