using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHitbox : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField]private float _attackDuration = 0.15f;
    [SerializeField]private float _attackCooldown = 0.5f;

    private Collider2D _collider;
    private bool _isAttacking = false;

    private IEnumerator _AttackCoroutine()
    {
        _collider.enabled = true;
        yield return new WaitForSeconds(_attackDuration);

        _collider.enabled = false;
        yield return new WaitForSeconds(_attackCooldown);

        _isAttacking = false;
    }

    public void Activate()
    {
        if (_isAttacking)
            return;

        _isAttacking = true;
        StartCoroutine(_AttackCoroutine());

    }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_damage);
        };
    }

}
