using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _movementSpeed = -100f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _playerVisual;

    public bool Enabled { get; set; } = true;
    
    private float _hAxis;
    private float _vAxis;

    private bool leftPressed;
    private bool rightPressed;

    private bool _isFacingRight = true;

    void Update()
    {
        _hAxis = Input.GetAxisRaw("Horizontal");
        _vAxis = Input.GetAxisRaw("Vertical");

        if (_hAxis == 0 && (leftPressed || rightPressed))
        {
            float v = leftPressed ? -1 : 0;
            v += rightPressed ? 1 : 0;
            _hAxis = v;
        }
        
        _animator?.SetBool("IsWalking", _hAxis != 0);

        if ((_isFacingRight && _hAxis < 0) || (!_isFacingRight && _hAxis > 0))
        {
            _playerVisual.localScale = new Vector3(_playerVisual.localScale.x, _playerVisual.localScale.y,
                -_playerVisual.localScale.z);
            _isFacingRight = !_isFacingRight;
        }
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
