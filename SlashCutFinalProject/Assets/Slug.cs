using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class Slug : MonoBehaviour
{
    
public float walkSpeed = 3f;

Rigidbody2D rb;
TouchingDirections touchingDirections;

public enum WalkableDirection{Right, Left}

private Vector2 WalkDirectionVector = Vector2.right;

private WalkableDirection _walkDirection;
public WalkableDirection WalkDirection
{
    get{return _walkDirection;}
    set{
        if(_walkDirection != value)
        {
            //change direction
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

            if(value == WalkableDirection.Right)
            {
                WalkDirectionVector = Vector2.right;

            } else if(value == WalkableDirection.Left)
            {
                WalkDirectionVector = Vector2.left;
            }
        
        }
        
        
        _walkDirection = value;}
}

private void Awake() {
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
    }
}

private void FixedUpdate()
{
    if(touchingDirections.IsGrounded && touchingDirections.IsOnWall)
    {
        FlipDirection();
    }
      rb.velocity = new Vector2(walkSpeed * WalkDirectionVector.x, rb.velocity.y);
}

private void FlipDirection()
{
    if(WalkDirection == WalkableDirection.Right)
    {
        WalkDirection = WalkableDirection.Left;
    } else if(WalkDirection == WalkableDirection.Left)
    {
        WalkDirection = WalkableDirection.Right;
    }else
    {
       Debug.LogError("Walkable direction is not set to right or left"); 
    }
}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
