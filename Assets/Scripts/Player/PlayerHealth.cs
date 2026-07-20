using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : IDamageable
{
   private int _health = 5;

   public void TakeDamage(int amount)
   {
      _health -= amount;
      Debug.Log(_health);
   }
}
