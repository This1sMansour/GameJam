using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public GameObject Wiggle;

    // Start is called before the first frame update
    void Start()
    {
        Wiggle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            wiggle();
        }

        if (Input.GetKeyDown("s"))
        {
            wiggle();
        }

        if (Input.GetKeyDown("a"))
        {
            wiggle();
        }

        if (Input.GetKeyDown("d"))
        {
            wiggle();
        }

        if (Input.GetKeyUp("w"))
        {
            StopWiggle();
        }

        if (Input.GetKeyUp("s"))
        {
            StopWiggle();
        }

        if (Input.GetKeyUp("a"))
        {
            StopWiggle();
        }

        if (Input.GetKeyUp("d"))
        {
            StopWiggle();
        }

    }

    void wiggle()
    {
        Wiggle.SetActive(true);
    }

    void StopWiggle()
    {
        Wiggle.SetActive(false);
    }
}
