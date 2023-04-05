using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class UIKeyHolder : MonoBehaviour
{
   [SerializeField] private KeyHolder keyHolder;
    private Transform container;
    private Transform keyTemplate;

    private void Awake() 
    {
        container = transform.Find("Container");
        keyTemplate = container.Find("KeyTemplate");
        keyTemplate.gameObject.SetActive(false);
    }
    
    private void Start() 
        {
            keyHolder.onKeyChanged += KeyHolder_onKeyChanged;
        }
    
    private void KeyHolder_onKeyChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

     private void UpdateVisual()
    {
         foreach(Transform child in container)
        {
            if(child == keyTemplate) continue;
            Destroy(child.gameObject);
        }

        List<Key.KeyType> keyList = keyHolder.GetkeyList();
        for(int i = 0; i < keyList.Count; i++ )
        {
            Key.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTransform.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * i, 0);
            Image keyImage = keyTransform.Find("Image").GetComponent<Image>();
            switch (keyType)
            {
                default:
                case Key.KeyType.Regular:   keyImage.color = Color.yellow;      break;
                case Key.KeyType.Boss:      keyImage.color = Color.black;      break;
                case Key.KeyType.Red:       keyImage.color = Color.red;         break;
                case Key.KeyType.Blue:      keyImage.color = Color.blue;        break;
                case Key.KeyType.Green:     keyImage.color = Color.green;       break;
               

            }
        }
    }
}
