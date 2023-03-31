using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class HealthBarScipt : MonoBehaviour
{
    Damagable playerDamageable;
    public TMP_Text healthBarText;
    public Slider healthSlider;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Debug.Log("no player found");
        }
        playerDamageable = player.GetComponent<Damagable>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        healthSlider.value = CalculateSliderPercentage(playerDamageable.Health, playerDamageable.MaxHealth);
        healthBarText.text = "HP " + playerDamageable.Health + " / " + playerDamageable.MaxHealth;
    }

    private void OnEnable()
    {
        playerDamageable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable()
    {
        playerDamageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private float CalculateSliderPercentage(float currentHealth, float maxHealth)
        {
            return currentHealth / maxHealth;
        }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth)
    {
        healthSlider.value = CalculateSliderPercentage(newHealth, maxHealth);
        healthBarText.text = "HP " + newHealth + " / " + maxHealth;
    }
}