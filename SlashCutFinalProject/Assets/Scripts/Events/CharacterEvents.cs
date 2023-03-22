using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using System.Linq;

public class CharacterEvents : MonoBehaviour
{
   //Character damaged and damage value
   public static UnityAction<GameObject, int> characterDamaged;
   //Character healed and amount value
   public static UnityAction<GameObject, int> characterHealed;
}
