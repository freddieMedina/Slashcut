using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    AudioSource pickupSource;
    [SerializeField] private Key.KeyType keyType;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    private void Awake() 
    {
        pickupSource = GetComponent<AudioSource>();
    }
    public void OpenDoor()
    {
        if(pickupSource)
                AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position,pickupSource.volume);
        gameObject.SetActive(false);
    }
}
