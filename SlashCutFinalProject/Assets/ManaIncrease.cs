using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManaIncrease : MonoBehaviour
{
    
    public int manaIncrease = 20;
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
        IncreaseManaHeal(manaIncrease);
        mana.currentMana = mana.maxMana;
            if(pickupSource)
                AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position,pickupSource.volume);
        
        
        mana.manaSlider.maxValue = mana.maxMana;
        mana.manaSlider.value = mana.CalculateSliderPercentage(mana.currentMana, mana.maxMana);
        mana.manaBarText.text = "MP " + mana.currentMana + " / " + mana.maxMana; 
        
        Destroy(gameObject);
        
        }
        
        public void IncreaseManaHeal(int manaIncrease)
    {
        mana.maxMana += manaIncrease;
        //manaChanged?.Invoke(mana.currentMana, mana.maxMana);
        CharacterEvents.increaseMana(gameObject, manaIncrease);
    }
   
   
}
