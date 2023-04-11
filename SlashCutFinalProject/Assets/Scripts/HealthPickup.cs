using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestore = 20;
    AudioSource pickupSource;

    void Start()
    {
        
    }

    private void Awake() 
    {
        pickupSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damagable = collision.GetComponent<Damagable>();

        if(damagable)
        {
            bool wasHealed = damagable.Heal(healthRestore);

            if(wasHealed){
                if(pickupSource)
                    AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position,pickupSource.volume);
            Destroy(gameObject);
            }
        }
    }
   

}
