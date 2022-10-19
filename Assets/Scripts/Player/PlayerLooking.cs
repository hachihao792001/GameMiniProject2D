using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] DetectEnemy _detectEnemy;

    [SerializeField] float _turnRate;

    void Update()
    {
        if (_detectEnemy.nearestEnemy != null)
        {
            transform.right = Vector3.Lerp(transform.right, (_detectEnemy.nearestEnemy.position - transform.position).normalized, _turnRate * Time.deltaTime);
        }
        else
        {
            if (_rb.velocity != Vector2.zero)
            {
                transform.right = Vector3.Lerp(transform.right, _rb.velocity.normalized, _turnRate * Time.deltaTime);
            }
        }
    }
}
