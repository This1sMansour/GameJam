using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    //public float smoothSpeed = 0.125f;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    void FixedUpdate () 
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = desiredPosition + smoothedPosition;

        transform.LookAt(target.position);
    }
}
