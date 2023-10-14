using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
   void Attack(Vector3 direction = new Vector3() , Vector3 point = new Vector3());
   void Attack(Vector3 direction);
   
}
