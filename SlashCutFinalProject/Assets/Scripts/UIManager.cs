using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class UIManager : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;
    public GameObject manaTextPrefab;
    public GameObject manaIncreaseTextPrefab;

    public Canvas gameCanvas;

    private void Awake() 
    {
        gameCanvas = FindObjectOfType<Canvas>();   
        
    }

    private void OnEnable()
    {
        CharacterEvents.characterDamaged += (CharacterTookDamage);
        CharacterEvents.characterHealed += (CharacterHealed);
        CharacterEvents.characterHealedMana += (CharacterHealedMana);
        CharacterEvents.increaseMana += (IncreasedMana);
    }

    private void OnDisable()
    {
        CharacterEvents.characterDamaged -= (CharacterTookDamage);
        CharacterEvents.characterHealed -= (CharacterHealed);
        CharacterEvents.characterHealedMana -= (CharacterHealedMana);
        CharacterEvents.increaseMana -= (IncreasedMana);
    }
    
    public void CharacterTookDamage(GameObject character, int damageRecieved)
    {
        //create text at hit
        Vector3 spawnPostition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(damageTextPrefab, spawnPostition, Quaternion.identity, gameCanvas.transform)
            .GetComponent<TMP_Text>();

        tmpText.text = damageRecieved.ToString();
    }

     public void CharacterHealed(GameObject character, int healthRestored)
    {
         //create text at hit
        Vector3 spawnPostition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(healthTextPrefab, spawnPostition, Quaternion.identity, gameCanvas.transform)
            .GetComponent<TMP_Text>();

        tmpText.text = healthRestored.ToString();
    }

    public void CharacterHealedMana(GameObject character, int manaRestored)
    {
         //create text at hit
        Vector3 spawnPostition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(manaTextPrefab, spawnPostition, Quaternion.identity, gameCanvas.transform)
            .GetComponent<TMP_Text>();

        tmpText.text = manaRestored.ToString();
    }

    public void IncreasedMana(GameObject character, int manaIncreased)
    {
         //create text at hit
        Vector3 spawnPostition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(manaTextPrefab, spawnPostition, Quaternion.identity, gameCanvas.transform)
            .GetComponent<TMP_Text>();

        tmpText.text = "Mana Max + " + manaIncreased.ToString() +"!";
    }
}
