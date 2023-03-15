using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections) )]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    Vector2 moveInput;
    public float jumpImpulse = 1f;
    TouchingDirections touchingDirections;

    
    LadderMovement ladder;
    LadderFloor floor;

    public bool isLadder;

   
    

    




    public float MoveWall{get
    {
        if(CanMove){

            if(IsMoving && !touchingDirections.IsOnWall)
        {
                
                return walkSpeed;
            }
        
            
        else{
          
            return 0;
        }
        }else
        {
            return 0;
        }
        
      
    
    }
    }

    [SerializeField]
    private bool _isMoving = false;

    private void Awake() 
    {
        rb =GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();

    }
    

    public bool IsMoving {get
    {
        return _isMoving;

    } 
    
    private set
    {
        _isMoving = value;
        animator.SetBool(AnimationStrings.isMoving, value);
    }

    
}
    private bool _isRunning = false;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set{
            _isRunning = value;
            animator.SetBool("isRunning", value);
        }
    }

    public bool _isFacingRight = true;
    public bool IsFacingRight {get {return _isFacingRight; } private set {
        if(_isFacingRight != value)
        {
            transform.localScale *= new Vector2(-1,1);
        }
        _isFacingRight = value;
    }
}
    Rigidbody2D rb;
    Animator animator;
    public bool CanMove{get 
        {
        return animator.GetBool(AnimationStrings.canMove);
        }
    }

    public bool IsAlive {
        get 
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(rb.gravityScale == 0f)
        {
            
            
            animator.SetBool("isClimbing", true);

            if(IsMoving == false){
                animator.speed =0;
        
        }
        else{
            animator.speed =1;
        }
        
        }

        if(rb.gravityScale != 0f)
        {
            
            animator.SetBool("isClimbing", false);
            animator.speed =1;
        }
    }


    private void FixedUpdate() 
    {
        
        rb.velocity = new Vector2(moveInput.x * MoveWall, rb.velocity.y);
        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
        
        
        
        

               
    }

    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if(IsAlive)
        {
            IsMoving = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        } else 
        {
            IsMoving = false;
        }
        
    }

    public void SetFacingDirection(Vector2 moveInput){

        if(moveInput.x > 0 && !IsFacingRight)
        {
            
            IsFacingRight =true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            
            IsFacingRight =false;
        }

    }

    public void onJumps(InputAction.CallbackContext context)
    {
        //TODO check if alive
        if(context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }


    public void onAttack(InputAction.CallbackContext context)
    {
        if(context.started && touchingDirections.IsGrounded)
        {
        animator.SetTrigger(AnimationStrings.attackTrigger);
        }

    }
}
