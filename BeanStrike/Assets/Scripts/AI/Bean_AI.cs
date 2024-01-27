using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean_AI : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float waypointSize = 0.1f;
    public float reachRadius = 0.2f;
    public  int beanTypeID = 1;
    public List<Transform> targetWaypoints;
    public Transform target;
    public float moveSpeed = 2f;
    public bool disableOnWaypoint = false;
    float reachRadiusOld;

    // Start is called before the first frame update
    void Start()
    {
        reachRadiusOld = reachRadius;
        GetNextTarget();
    }

    // Update is called once per frame
    void Update()
    {
        // Apply move
        transform.position = Vector3.MoveTowards(transform.position, LookForPathPoint(), moveSpeed * Time.deltaTime);

        // Destroy gameobject if reached waypoint
        if (Vector3.Distance(transform.position, target.position) <= reachRadius && disableOnWaypoint)
        {
            Destroy(gameObject);
        }

        // Get next waypoint if reached waypoint
        if (Vector3.Distance(transform.position, target.position) <= reachRadius)
        {
            GetNextTarget();
        }
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

    public void GetNextTarget()
    {
        if (targetWaypoints.Count > 0)
        {
            int waypointIndex = Random.Range(0, (targetWaypoints.Count - 1));
            target = targetWaypoints[waypointIndex];
            return;
        }
        target = transform;
        return;
    }

    public void ResetReachRadius()
    {
        reachRadius = reachRadiusOld;
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, reachRadius);
    }
}
