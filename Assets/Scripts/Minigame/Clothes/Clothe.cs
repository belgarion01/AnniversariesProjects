using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clothe : MonoBehaviour
{
    [SerializeField] private Vector2 _fallingSpeedMinMax;

    public UnityEvent<Clothe> OnPlayerHit;

    private float _fallingSpeed;

    void Start()
    {
        _fallingSpeed = _fallingSpeedMinMax.RandomFloat();
    }
    
    private void Update()
    {
        transform.Translate(0f, -_fallingSpeed * Time.deltaTime, 0f);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            OnPlayerHit?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
