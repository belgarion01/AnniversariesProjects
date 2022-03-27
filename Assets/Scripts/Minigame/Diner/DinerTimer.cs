using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class DinerTimer
{
    public DinerTimer(DinerTimer.Settings settings)
    {
        ArrowAngleSpeed = settings.ArrowAngleSpeed;
        SuccessAngleSpeed = settings.SuccessAngleSpeed;
        float angleOffset = Random.Range(0f, settings.SuccessAngle);
        SuccessAngle = new Vector2(angleOffset, settings.SuccessAngle + angleOffset);
    }
    
    public bool IsArrowCorrect
    {
        get
        {
            return IsBewteen(SuccessAngle.x % 360f, SuccessAngle.y % 360f, ArrowAngle % 360f);
        }
    }

    public float ArrowAngle
    {
        get => _arrowAngle;
        set
        {
            _arrowAngle = value;
            OnArrowAngleChanged?.Invoke(_arrowAngle);
        }
    }

    public Vector2 SuccessAngle
    {
        get => _successAngle;
        set
        {
            _successAngle = value;
            OnSuccessAngleChanged?.Invoke(_successAngle);
        }
    }
    
    //Parameters
    public float SuccessAngleSpeed = 0f;
    public float ArrowAngleSpeed = 1f;
    
    //Events
    public Action<Vector2> OnSuccessAngleChanged;
    public Action<float> OnArrowAngleChanged;

    //Privates
    private float _arrowAngle;
    private Vector2 _successAngle;
    
    public void Tick()
    {
        // Tick Arrow
        ArrowAngle = _arrowAngle += ArrowAngleSpeed * Time.deltaTime;

        if (SuccessAngleSpeed > 0)
        {
            SuccessAngle += Vector2.one * SuccessAngleSpeed * Time.deltaTime;
        }
    }
    
    [Serializable]
    public struct Settings
    {
        public float ArrowAngleSpeed;
        public float SuccessAngle;
        public float SuccessAngleSpeed;

        public Settings(float arrowSpeed, float successAngleSpeed, float successAngle)
        {
            ArrowAngleSpeed = arrowSpeed;
            SuccessAngleSpeed = successAngleSpeed;
            SuccessAngle = successAngle;
        }
    }

    public bool IsBewteen(float start, float end, float mid)
    {
        end = (end - start) < 0.0f ? end - start + 360.0f : end - start;    
        mid = (mid - start) < 0.0f ? mid - start + 360.0f : mid - start; 
        return (mid < end); 
    }
}
