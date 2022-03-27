using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClothesSwitcherButton : MonoBehaviour
{
    [SerializeField] private SwitcherDirection _direction;

    public UnityEvent<SwitcherDirection> OnClicked;
    
    public enum SwitcherDirection
    {
        Previous,
        Next
    }
    
    void OnMouseUp()
    {
        OnClicked?.Invoke(_direction);
    }
}
