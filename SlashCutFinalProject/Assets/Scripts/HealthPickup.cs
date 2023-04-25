using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HealthPickup : MonoBehaviour
{
    public int healthRestore = 20;
    AudioSource pickupSource;
    AudioMixer mixer;

    void Start()
    {
        
    }

    private void Awake() 
    {
        pickupSource = GetComponent<AudioSource>();
        mixer = GetComponent<AudioMixer>();

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
