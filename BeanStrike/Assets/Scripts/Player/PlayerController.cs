using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    private float previousMovement; // Start with character look right


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        previousMovement = 1;
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if ((previousMovement > 0 && Input.GetAxis("Horizontal") < 0) || (previousMovement < 0 && Input.GetAxis("Horizontal") > 0))
        {
            Rotate180Degrees();
            previousMovement = Input.GetAxis("Horizontal");
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }

    private void Rotate180Degrees()
    {
        // Get the current rotation
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Set the new rotation with a 180-degree change around the y-axis
        Vector3 newRotation = new Vector3(currentRotation.x, currentRotation.y + 180f, currentRotation.z);

        // Apply the new rotation
        transform.rotation = Quaternion.Euler(newRotation);
    }

}