using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanOrigin : MonoBehaviour
{
    public float spawnCooldown = 5f;        // In seconds
    public int spawnLimit = 50;             // Max beans
    public List<GameObject> beanTypes;      // List of bean prefabs
    public List<Transform> waypoints;       // List of escape waypoints

    public float currentCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBean();
    }

    void SpawnBean()
    {
        if (beanTypes.Count > 0 && waypoints.Count > 0 && currentCooldown <= 0f && transform.childCount < spawnLimit)
        {
            // Select random bean type
            int beanType = Random.Range(0, (beanTypes.Count - 1));

            // Instantiate bean and set its parameter waypoint
            GameObject bean = Instantiate(beanTypes[beanType], transform.position, Quaternion.identity, transform);
            bean.GetComponent<Bean_AI>().targetWaypoints = waypoints;

            currentCooldown = spawnCooldown;
        }
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);

        if (waypoints.Count > 0)
        {
            foreach (Transform waypoint in waypoints)
            {
                if (waypoint != null)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawSphere(waypoint.position, 0.1f);
                }
            }

        }
    }
}
