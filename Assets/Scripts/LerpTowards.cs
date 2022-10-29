using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTowards : MonoBehaviour
{
    Transform _target;
    [SerializeField] float _lerpRateIncrease;
    [SerializeField] float _startLerpRate;
    float _lerpRate;

    public void Init(Transform target)
    {
        _target = target;
        _lerpRate = _startLerpRate;
    }

    private void Update()
    {
        if (_target != null)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, _lerpRate * Time.deltaTime);
            _lerpRate += _lerpRateIncrease * Time.deltaTime;
        }
    }
}
