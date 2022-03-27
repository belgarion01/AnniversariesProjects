using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSwitcher : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _renderer;

    private int _index = 0;

    void Start()
    {
        if (_sprites.Length > 0)
        {
            SetSprite(0);
        }
    }

    private void SetSprite(int index)
    {
        if (index >= _sprites.Length || index < 0)
        {
            Debug.LogError("Invalid index");
            return;
        }

        _renderer.sprite = _sprites[index];
        _index = index;
    }

    public void NextSprite()
    {
        int targetIndex = _index + 1;
        
        if (targetIndex >= _sprites.Length)
        {
            targetIndex = 0;
        }
        
        SetSprite(targetIndex);
    }

    public void PreviousSprite()
    {
        int targetIndex = _index - 1;
        
        if (targetIndex < 0)
        {
            targetIndex = _sprites.Length - 1;
        }
        
        SetSprite(targetIndex);
    }

    public void OnButtonClicked(ClothesSwitcherButton.SwitcherDirection direction)
    {
        switch (direction)
        {
            case ClothesSwitcherButton.SwitcherDirection.Previous:
                PreviousSprite();
                break;
            case ClothesSwitcherButton.SwitcherDirection.Next:
                NextSprite();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}
