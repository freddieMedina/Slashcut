using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
   public GameObject dialoguePanel;
   public Text dialogueText;
   public string[] dialogue;

   private int index;
    public float wordSpeed;
    public bool playerIsClose;
    public bool endText;

    void Start()
    {
        dialogueText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.D) && playerIsClose)
        // {
            
        // }
    }

    public void NextLine()
    {
        if(index < dialogue.Length -1)
        {
            index++;
            dialogueText.text = null;
            StartCoroutine(Typing());
        }else
        {
            zeroText();
        }
    }

    public void zeroText()
    {
        dialogueText.text = null;
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"));
        {
            if(dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }    
    }

     private void OnTriggerExit2D(Collider2D other) 
    {
        // if(other.CompareTag("Player"));
        // {
            Destroy(gameObject);
            zeroText();
      //  }    
    }
}
