using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    
    public int manaRestore = 20;
    AudioSource pickupSource;
    public ManaBarScript mana;

    void Start()
    {
        
    }

    private void Awake() 
    {
        pickupSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mana.currentMana += manaRestore;
            if(pickupSource)
                AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position,pickupSource.volume);
        
        if(mana.currentMana > 100)
            mana.currentMana = mana.maxMana;
        mana.manaSlider.value = mana.CalculateSliderPercentage(mana.currentMana, mana.maxMana);
        mana.manaBarText.text = "MP " + mana.currentMana + " / " + mana.maxMana; 
        Destroy(gameObject);
        }
        
    
   

}
