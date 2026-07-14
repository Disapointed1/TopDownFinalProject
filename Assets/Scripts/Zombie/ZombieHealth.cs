using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour, IDamageable
{
    public void TakeDamage(int damage)
    {
        Destroy(this.gameObject);
    }
}
