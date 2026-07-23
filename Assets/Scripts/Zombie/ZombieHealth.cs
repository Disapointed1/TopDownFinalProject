using System;
using UnityEngine;

public class ZombieHealth : MonoBehaviour, IDamageable
{
    public event Action OnZombieDeath;

    public void TakeDamage(int damage)
    {
        OnZombieDeath?.Invoke();
        Destroy(this.gameObject);
    }
}
