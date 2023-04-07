using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Transform pointA, pointB;
    [SerializeField] private float speed;

    private Vector2 targetPos;

    void Start(){
        targetPos = pointB.position;
    }

    void Update(){
        if(Vector2.Distance(transform.position, pointA.position) < 0.1f) targetPos = pointB.position;
        if(Vector2.Distance(transform.position, pointB.position) < 0.1f) targetPos = pointA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            collision.transform.SetParent(this.transform);
            
        }
    }

     private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
     {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(pointA.position, pointB.position);
     }

}
