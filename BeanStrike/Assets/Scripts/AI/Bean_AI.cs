using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean_AI : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float waypointSize = 0.1f;
    public Transform target;
    public float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Assign the first unobscurred sensor to the current point variable
        /*for (int i = 0; i < sensors.Count; i++)
        {
            if (CheckForObstacles(sensors[i].position) == null)
            {
                currentPoint = sensors[0];
            }
        }

        // Go through the rest of the sensors
        for (int i = 1; i < sensors.Count; i++)
        {
            // If the current point is farther away than the sensors[i] point, replace it
            if (Vector3.Distance(sensors[i].position, waypoint.position) < Vector3.Distance(currentPoint.position, waypoint.position) && CheckForObstacles(sensors[i].position) == null)
            {
                currentPoint = sensors[i];
            }
        }*/

        // Apply move
        transform.position = Vector3.MoveTowards(transform.position, LookForPathPoint(), moveSpeed * Time.deltaTime);
    }

    Vector3 LookForPathPoint()
    {
        if (waypoints.Count > 0)
        {
            Vector3 currentPoint = waypoints[0].position;

            // Find the first unobscurred waypoint
            foreach (Transform waypoint in waypoints)
            {
                if (WaypointObscurred(waypoint.position) == null)
                {
                    currentPoint = waypoint.position;
                    break;
                }
            }

            // Find the closest waypoint to the target with the condition that it is not obscurred
            foreach (Transform waypoint in waypoints)
            {
                if (Vector3.Distance(waypoint.position, target.position) < Vector3.Distance(currentPoint, target.position) && WaypointObscurred(waypoint.position) == null)
                {
                    currentPoint = waypoint.position;
                }
            }
            // If it is unobscurred, return it
            if (WaypointObscurred(currentPoint) == null)
                return new Vector3(currentPoint.x, currentPoint.y, currentPoint.z);
        }
        return transform.position;
    }

    Collider2D WaypointObscurred(Vector3 waypointPositon)
    {
        return Physics2D.OverlapCircle(new Vector2(waypointPositon.x, waypointPositon.y), waypointSize);
    }

    void OnDrawGizmos()
    {
        if (waypoints.Count > 0)
        {
            foreach (Transform waypoint in waypoints)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(waypoint.position, waypointSize);
            }
        }
    }
}
