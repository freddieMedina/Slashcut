using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;


public class charPortraitController : MonoBehaviour
{

    Damagable damagable;
    public Image Portrait;

    public Sprite Low;
    // Start is called before the first frame update
    void Start()
    {
     //port = gameObject.GetComponent<Image>();
     //Low = Resources.Load <Sprite>("Art/Low");  //FULL
     //LESSHP = Resources.Load <Sprite>("suit_life_meter_0");     //-1
     //NOHP = Resources.Load <Sprite>("suit_life_meter_1");  //EMPTY
    }

    // Update is called once per frame
    void Update()
    {
        //  if(damagable.Health >= 50)
        //  {
         //    Portrait.sprite = Low;
        //  }
    }
}
