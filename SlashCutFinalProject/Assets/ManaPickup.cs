using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManaPickup : MonoBehaviour
{
    public UnityEvent<int, int> manaChanged;
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
        ManaHeal(manaRestore);
            if(pickupSource)
                AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position,pickupSource.volume);
        
        if(mana.currentMana > mana.maxMana)
            mana.currentMana = mana.maxMana;
        
        mana.manaSlider.value = mana.CalculateSliderPercentage(mana.currentMana, mana.maxMana);
        mana.manaBarText.text = "MP " + mana.currentMana + " / " + mana.maxMana; 
        Destroy(gameObject);
        
        }
        
    public void ManaHeal(int manaRestore)
    {
        mana.currentMana += manaRestore;
        //manaChanged?.Invoke(mana.currentMana, mana.maxMana);
        CharacterEvents.characterHealedMana(gameObject, manaRestore);
    }
   

}
