using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PressedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent<bool> OnPressedChanged;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        OnPressedChanged?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPressedChanged?.Invoke(false);
    }
}
