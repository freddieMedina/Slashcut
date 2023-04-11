using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damagable))]
public class Slug : MonoBehaviour
{
    

public float walkSpeed = 1f;
public float walkStopRate = 1f;
public DetectionZone attackZone;
public DetectionZone cliffDetectionZone;



Rigidbody2D rb;
TouchingDirections touchingDirections;
Animator animator;
Damagable damagable;

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

public bool _hasTarget = false;
public bool HasTarget{
    get {return _hasTarget;} 
    private set
    {   
    _hasTarget = value;
    animator.SetBool(AnimationStrings.hasTarget, value);
    }
}
public bool CanMove
{
    get
    {
        return animator.GetBool(AnimationStrings.canMove);
    }
}

public float attackCooldown {get{
    return animator.GetFloat(AnimationStrings.attackCooldown);
} private set{
    animator.SetFloat(AnimationStrings.attackCooldown, Mathf.Max(value, 0));
}}

private void Awake() {
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
        damagable =GetComponent<Damagable>();
    }
}

// Update is called once per frame
    void Update()
    {
        HasTarget = attackZone.detectedColliders.Count >0;
        
        if(attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        
    }
private void FixedUpdate()
{
    if(touchingDirections.IsGrounded && touchingDirections.IsOnWall)
    {
        FlipDirection();
    }

    if(!damagable.LockVelocity)
    {
    if(CanMove)
      rb.velocity = new Vector2(walkSpeed * WalkDirectionVector.x, rb.velocity.y);
    else
        rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x,0, walkStopRate),rb.velocity.y);
    }
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
        
public void OnHit(int damage, Vector2 knockback) {
    {
        
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
        if(damagable.IsAlive == false && damagable.Health <= 0 )
        {
            damagable.ItemDrop();
        }
    }
}

public void OnCliffDetected()
{
    if(touchingDirections.IsGrounded)
    {
        FlipDirection();
    }
}

    

}
