using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] JoyStick _joyStick;
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;

    public float bonusSpeed = 0;

    private void Start()
    {
        bonusSpeed = 0;
    }

    private void Update()
    {
        Vector2 pcInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (pcInput != Vector2.zero)
            _rb.velocity = pcInput * (_speed + bonusSpeed);
        else
            _rb.velocity = _joyStick.Input * (_speed + bonusSpeed);
    }

    public void AddBonusSpeed(float value)
    {
        bonusSpeed += value;
    }
}
