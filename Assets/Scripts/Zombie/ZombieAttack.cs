using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class ZombieAttack : MonoBehaviour
{
    [Inject] private PlayerContext _playerContext;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _attackDelay = 0.5f;
    private Coroutine _coroutine;


    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(_attackDelay);
        _playerContext.PlayerHealth.TakeDamage(_damage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out var _))
        {
            if (_coroutine != null)
                return;
            _coroutine = StartCoroutine(AttackCoroutine());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out var _))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }
}