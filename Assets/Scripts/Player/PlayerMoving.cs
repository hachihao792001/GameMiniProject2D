using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] JoyStick _joyStick;
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;

    public float bonusSpeed = 0;
    bool isLockingMoving;

    private void Start()
    {
        bonusSpeed = 0;
        _joyStick.gameObject.SetActive(GameInformation.IsPhone);
        isLockingMoving = false;
    }

    private void Update()
    {
        if (isLockingMoving) return;
        Vector2 pcInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (pcInput.magnitude > 1)
            pcInput.Normalize();

        if (pcInput != Vector2.zero)
            _rb.velocity = pcInput * (_speed + bonusSpeed);
        else
            _rb.velocity = _joyStick.Input * (_speed + bonusSpeed);
    }

    public void AddBonusSpeed(float value)
    {
        bonusSpeed += value;
    }

    public bool IsMoving => _rb.velocity != Vector2.zero;
    public void LockJoyStick()
    {
        _joyStick.OnPointerUp(null);
        _joyStick.Lock();
    }
    public void UnlockJoyStick()
    {
        _joyStick.Unlock();
    }

    public void LockMoving()
    {
        if (GameInformation.IsPhone)
            LockJoyStick();

        _rb.velocity = Vector2.zero;
        isLockingMoving = true;
    }

    public void UnlockMoving()
    {
        if (GameInformation.IsPhone)
            UnlockJoyStick();

        isLockingMoving = false;
    }
}
