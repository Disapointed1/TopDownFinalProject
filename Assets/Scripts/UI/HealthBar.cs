using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HealthBar : Bar
{
    [Inject] private PlayerHealth _playerHealth;


    private void OnEnable()
    {
        Debug.Log(_playerHealth);
        _playerHealth.OnHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(int currentHealth)
    {
        OnValueChanged(currentHealth, _playerHealth.MaxHealth);
    }
}
