using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.InputSystem;

public class ManaBarScript : MonoBehaviour
{    
    public Slider staminaSlider;
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDepletionRate = 20f;
    public PlayerInput pi;
    
    

    // Start is called before the first frame update
    void Start()
    {
        pi = GetComponent<PlayerInput>();
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = currentStamina;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(currentStamina <= 0f)
        {
            pi.actions.FindAction("RangedAttack").Disable();
        }else
        {
            pi.actions.FindAction("RangedAttack").Enable();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            UseStamina(staminaDepletionRate);
        }
        staminaSlider.value = currentStamina;
    }

    public void DecreaseStamina(float amount)
    {
        currentStamina -= amount;
        if (currentStamina < 0f)
        {
            currentStamina = 0f;
        }
    }

    public void IncreaseStamina(float amount)
    {
        currentStamina += amount;
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }

    public void UseStamina(float amount)
    {
        if (currentStamina >= amount)
        {
            DecreaseStamina(amount);
            // Perform action here that uses stamina, e.g. running
        }
        else
        {
            // Not enough stamina to perform action
            Debug.Log("Not enough stamina!");
        }
    }
}
