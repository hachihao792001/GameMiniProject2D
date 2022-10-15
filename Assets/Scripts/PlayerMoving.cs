using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] JoyStick _joyStick;
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _sr;

    private void Update()
    {
        _rb.velocity = _joyStick.Input * _speed;
        if (_rb.velocity.x != 0)
            _sr.flipX = _rb.velocity.x < 0;
    }
}
