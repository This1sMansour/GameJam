using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanExit : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] string beanTag = "bean";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collided with tag: " + col.gameObject.tag);
        if (col.gameObject.tag == beanTag)
        {
            gameManager.score += col.gameObject.GetComponent<Bean_AI>().points;
            Destroy(col.gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
