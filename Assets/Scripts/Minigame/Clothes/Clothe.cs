using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Clothe : MonoBehaviour
{
    [SerializeField] private Vector2 _fallingSpeedMinMax;
    [SerializeField] private Vector2 _rotationSpeedMinMax;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _renderer;

    public UnityEvent<Clothe> OnPlayerHit;

    private float _fallingSpeed;
    private float _rotationSpeed;

    void Start()
    {
        _fallingSpeed = _fallingSpeedMinMax.RandomFloat();
        _rotationSpeed = _rotationSpeedMinMax.RandomFloat() * (Random.Range(0, 2) == 0 ? 1 : -1);
        _renderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
    }
    
    private void Update()
    {
        transform.Translate(0f, -_fallingSpeed * Time.deltaTime, 0f, Space.World);
        transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.forward);
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
