using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.InputSystem;

public class ManaBarScript : MonoBehaviour
{    
    Damagable damagable;
    public Slider manaSlider;
    public int maxMana = 100;
    //public float currentMana;
    public int manaDepletionRate = 20;
   public PlayerController pi;
   //public ManaPickup potion;
  

    public TMP_Text manaBarText;

    
    [SerializeField]
    private bool isCoolDown = false;
  
    private float timeSinceRanged = 0f;
    public float coolDownTime = 100f;


    [SerializeField]
    private int _mana = 100;

    
    public int currentMana
    {
        get
        {
            return _mana;
        }
        set
        {
           _mana = value; 
           
          
           
        }
    }
    
    

    // Start is called before the first frame update
    void Start()
    {
        manaSlider.value = CalculateSliderPercentage(currentMana, maxMana);
        manaBarText.text = "MP " + currentMana + " / " + maxMana;
        //pi = GetComponent<PlayerInput>();
        //currentMana = maxMana;
        manaSlider.maxValue = maxMana;
        manaSlider.value = currentMana;
        pi.CanRange = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentMana < 20)
        {
            pi.CanRange = false;
            isCoolDown = true;
        }else{

       

       if(isCoolDown)
            {
                if(timeSinceRanged > coolDownTime)
                {
                    //Remove cooldown
                    pi.CanRange = true;
                    isCoolDown = false;
                    timeSinceRanged = 0;
                }

                timeSinceRanged += Time.deltaTime;
            }
       
        if (Input.GetKeyDown(KeyCode.F) && !isCoolDown && currentMana >= 20 && pi.CanRange)
        {
            pi.CanRange = false;
            isCoolDown = true;
            UseMana(manaDepletionRate);
        }
        }
        
        manaSlider.value = currentMana;
    }

    public void DecreaseMana(int amount)
    {
        currentMana -= amount;
        manaSlider.value = CalculateSliderPercentage(currentMana, maxMana);
        manaBarText.text = "MP " + currentMana + " / " + maxMana;
        
        if (currentMana < 0)
        {
            currentMana = 0;
        }
    }

    public void IncreaseMana(int amount)
    {
        currentMana += amount;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }

    public void UseMana(int amount)
    {
        if (currentMana >= amount)
        {
            DecreaseMana(amount);

            // Perform action here that uses mana, e.g. running
        }
        else
        {
            // Not enough mana to perform action
            Debug.Log("Not enough mana!");
        }
    }

    public float CalculateSliderPercentage(int currentMana, int maxMana)
        {
            return currentMana / maxMana;
        }
}
