using UnityEngine;
using System.Collections;

public class PowerMeter : MonoBehaviour
{
    bool moveRight = true;
    bool stopped = false;
    public float rightSpeed;
    public float leftSpeed;
    public float maxLength = 10;
    public float minLength = 0;

    bool movingRight = true;
    bool movingLeft = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //if the mouse is clicked
        {
            stopped = true;  //then stop
            movingRight = false;
            movingLeft = false;
            transform.Translate(Vector3.right * 0 * Time.deltaTime);
            transform.Translate(Vector3.left * 0 * Time.deltaTime);
        }
        else if (transform.position.x <= minLength)
        {
            movingRight = true;
            movingLeft = false;
        }
        else if (transform.position.x >= maxLength)
        {
            movingRight = false;
            movingLeft = true;
        }
        if (!movingRight && movingLeft && !stopped) //if we haven't stopped
        {
            MoveLeft();
        }
        if (movingRight && !movingLeft && !stopped)
        {
            MoveRight();
        }
    }


    void MoveRight()
    {
        Debug.Log("Move to the right");
        transform.Translate(Vector3.right * rightSpeed * Time.deltaTime);
    }

    void MoveLeft()
    {
        Debug.Log("Reached maximum length to the right");
        transform.Translate(Vector3.left * leftSpeed * Time.deltaTime);
    }

}
