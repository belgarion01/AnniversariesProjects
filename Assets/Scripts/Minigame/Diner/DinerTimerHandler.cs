using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DinerTimerHandler : MonoBehaviour
{
    public DinerTimer CurrentDinerTimer
    {
        get => _currentDinerTimer;
        set
        {
            _currentDinerTimer = value;
            OnTimerValueChanged?.Invoke(_currentDinerTimer);
        }
    }

    private DinerTimer _currentDinerTimer;

    public UnityEvent<DinerTimer> OnTimerValueChanged;

    public bool IsArrowCorrect => _currentDinerTimer.IsArrowCorrect;

    void Update()
    {
        if (_currentDinerTimer != null)
        {
            _currentDinerTimer.Tick();
            OnTimerValueChanged?.Invoke(_currentDinerTimer);
        }
    }
}
