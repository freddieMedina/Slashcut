using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler onKeyChanged;
    private List<Key.KeyType> keyList;

    public List<Key.KeyType> GetkeyList()
    {
        return keyList;
    }
    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key:" + keyType);
        keyList.Add(keyType);
        onKeyChanged?.Invoke(this , EventArgs.Empty);
    }
    
    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        onKeyChanged?.Invoke(this , EventArgs.Empty);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Key key = collider.GetComponent<Key>();
        if( key != null )
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(keyDoor != null)     
        {
            if(ContainsKey(keyDoor.GetKeyType()))
            {
                //Currently holding key to open this door
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
                
            }
        }
    }



}
