using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 5f;
    public List<Collider2D> beans;
    public LayerMask targetLayer;
    public Transform mainTarget;

    // Start is called before the first frame update
    void Start()
    {
        beans = new List<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectBeans();
        if (Input.GetKeyDown("1"))
        {
            CallBeans(1);
        }
        if (Input.GetKeyDown("2") && Vector3.Distance(transform.position, mainTarget.position) <= interactionRange)
        {
            DirectBeans();
        }
        if (Input.GetKeyDown("3"))
        {
            DiscardBeans();
        }
    }

    void CallBeans(int beanID)
    {
        foreach (Collider2D bean in beans)
        {
            if (bean.gameObject.GetComponent<Bean_AI>().beanTypeID == beanID)
            {
                bean.gameObject.GetComponent<Bean_AI>().target = transform;
            }
        }
    }

    void DiscardBeans()
    {
        foreach (Collider2D bean in beans)
        {
            bean.gameObject.GetComponent<Bean_AI>().stopAtWaypoint = false;
            bean.gameObject.GetComponent<Bean_AI>().ResetReachRadius();
            bean.gameObject.GetComponent<Bean_AI>().GetNextTarget();
        }
    }

    void DirectBeans()
    {
        foreach (Collider2D bean in beans)
        {
            bean.gameObject.GetComponent<Bean_AI>().stopAtWaypoint = true;
            bean.gameObject.GetComponent<Bean_AI>().reachRadius = 0.5f;
            bean.gameObject.GetComponent<Bean_AI>().target = mainTarget;
        }
    }

    void DetectBeans()
    {
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(targetLayer);
        Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), interactionRange, filter, beans);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
