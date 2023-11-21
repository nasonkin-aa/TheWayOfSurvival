using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
   public enum Type
   {
      Ground,
      Sky
   }

   public enum Enemy
   {
      None,
      Bird,
      Vann,
      Draugr,
      Troll,
      Fairy,
      Wolf
   }
   
   public Type enemy;
   public Enemy nameEnemy;
}
