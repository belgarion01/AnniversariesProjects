using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

[DisplayName("Health")]
public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _startingHealth;

    public int Health => _health;
    public UnityEvent<int> OnHealthChanged;
    public UnityEvent OnGameOver;
    
    private int _health;

    private void Awake()
    {
        _health = _startingHealth;
    }
    
    public void SetHealth(int newHealth)
    {
        int oldHealth = _health;
        
        _health = Mathf.Max(newHealth, 0);

        if (oldHealth != _health)
        {
            OnHealthChanged?.Invoke(_health);
        }

        if (_health == 0)
        {
            OnGameOver?.Invoke();
        }
    }

    public void ResetHealth() => SetHealth(_startingHealth);
    public void AddHealth(int healthToAdd) => SetHealth(_health + healthToAdd);
    public void SubstractHealth(int healthToSubstract) => SetHealth(_health - healthToSubstract);
}
