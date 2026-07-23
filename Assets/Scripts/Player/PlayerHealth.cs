using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : IDamageable
{
   public int MaxHealth { get; private set; } = 5;

   private int _health = 5;

   public event Action<int> OnHealthChanged;
   public event Action OnPlayerDeath;

   public void TakeDamage(int amount)
   {
      _health -= amount;
      OnHealthChanged?.Invoke(_health);
      if (_health <= 0)
      {
         OnPlayerDeath?.Invoke();
      }
   }
}
