using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _movementSpeed = -100f;

    public bool Enabled { get; set; } = true;
    
    private float _hAxis;
    private float _vAxis;

    private bool leftPressed;
    private bool rightPressed;

    void Update()
    {
#if UNITY_EDITOR
        _hAxis = Input.GetAxisRaw("Horizontal");
        _vAxis = Input.GetAxisRaw("Vertical");
#else
        _hAxis = rightPressed ? 1f : -1f;
        _vAxis = leftPressed ? 1f : -1f;
#endif
    }

    void FixedUpdate()
    {
        
        _rb2d.velocity = Enabled ? new Vector3(_hAxis * _movementSpeed, _gravity) * Time.fixedDeltaTime : Vector2.zero;
    }
    
    public void OnLeftMovementChanged(bool pressed)
    {
        leftPressed = pressed;
    }

    public void OnRightMovementChanged(bool pressed)
    {
        rightPressed = pressed;
    }
}
