using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image _healthImage;
    [SerializeField] private Transform _healthContainer;
    [SerializeField] private HealthComponent _healthComponent;

    void Start()
    {
        _healthComponent.OnHealthChanged.AddListener(health => UpdateUI(health)); 
        UpdateUI(_healthComponent.Health);
    }

    void UpdateUI(int health)
    {
        _healthContainer.ClearChildrens();

        for (int i = 0; i < health; i++)
        {
            Instantiate(_healthImage, _healthContainer);
        }
    }
}
