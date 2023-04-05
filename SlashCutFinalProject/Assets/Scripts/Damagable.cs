using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Damagable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damagableHit;
    public UnityEvent<int, int> healthChanged;
    Animator animator;

    public GameObject [] itemDrops;

    [SerializeField]
    private int _maxHealth = 100;
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField]
    private int _health = 100;

    
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
           _health = value; 
           healthChanged?.Invoke(_health, MaxHealth);
           //If health reaches 0, character dies
           if(_health <= 0)
           {
            IsAlive = false;
           }
        }
    }

    [SerializeField]
    private bool _isAlive = true;
    
    [SerializeField]
    private bool isInvincible = false;
    // public bool IsHit {get 
    // {
    //     return animator.GetBool(AnimationStrings.isHit);
    // }


    //  private set
    //  {
    //     animator.SetBool(AnimationStrings.isHit, value);
    //  }
    //  }
    private float timeSinceHit = 0f;
    public float invincibilityTime = 0.25f;

    public bool IsAlive {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("Is Alive set" + value);
        } 
    }

    public bool LockVelocity{get
     {
        return animator.GetBool(AnimationStrings.lockVelocity);
     }
     set
     {
        animator.SetBool(AnimationStrings.lockVelocity, value);
     }
    }

    private void Awake()
     {
        animator = GetComponent<Animator>();   
     }
    
    private void Update() 
        {
            if(isInvincible)
            {
                if(timeSinceHit > invincibilityTime)
                {
                    //Remove invincibility
                    isInvincible = false;
                    timeSinceHit = 0;
                }

                timeSinceHit += Time.deltaTime;
            }

           
        }
    
    public bool Hit(int damage, Vector2 knockback)
    {
        if(IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;

            animator.SetTrigger(AnimationStrings.hitTrigger);
            LockVelocity = true;
            damagableHit?.Invoke(damage,knockback);
            CharacterEvents.characterDamaged.Invoke(gameObject, damage);

            return true;
        }
        
        return false;
    }

    public bool Heal(int healthRestore)
    {

    if(IsAlive && Health < MaxHealth)
    {   
        int maxHeal = Mathf.Max(MaxHealth -Health, 0);
        int actualHealth = Mathf.Min(maxHeal, healthRestore);
        Health += actualHealth;
        
        CharacterEvents.characterHealed(gameObject, actualHealth);
        return true;
    }
         return false;
    }

    public void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i],transform.position + new Vector3(0,1,0), Quaternion.identity);

        }
    }
         
}
