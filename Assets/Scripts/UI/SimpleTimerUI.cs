using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleTimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMeshPro;
    
    public void UpdateText(float time)
    {
        _textMeshPro.text = Mathf.Ceil(time).ToString();
    }
}
