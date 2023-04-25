using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public GameObject portal;
    
  private void OnTriggerExit2D(Collider2D other) 
    {
        // if(other.CompareTag("Player"));
        // {
            Destroy(gameObject);
            
      //  }    
    }
}
