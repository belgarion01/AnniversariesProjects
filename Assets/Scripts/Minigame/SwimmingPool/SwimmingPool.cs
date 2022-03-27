using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwimmingPool : MonoBehaviour
{
    public UnityEvent OnEnter;

    public void TriggerOnEnterEvent()
    {
        OnEnter?.Invoke();
    }
}
