using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 moveSpeed = new Vector2(3f,0);
    public int damage = 30;
    public Vector2 knockback = Vector2.zero;

    

    Rigidbody2D rb;

    private void Awake() {
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Damagable damagable = collision.GetComponent<Damagable>();

        if(damagable != null)
        {
            Vector2 deliveredKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            //Hit target
            bool gotHit = damagable.Hit(damage, deliveredKnockback);
            
            if(gotHit)
            Debug.Log(collision.name + "hit for" + damage);
            Destroy(gameObject);
        }
    }
}
