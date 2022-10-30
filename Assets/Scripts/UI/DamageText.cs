using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    [SerializeField] Text _txt;

    [SerializeField] float _moveUpSpeed;
    [SerializeField] float _fadeSpeed;

    [SerializeField] Transform _followTarget;
    float currentUpOffset = 0;
    public void Init(float damage)
    {
        _followTarget = new GameObject().transform;
        _followTarget.position = GameController.Instance.MainCamera.ScreenToWorldPoint(transform.position) - Vector3.up * currentUpOffset;
        _txt.text = damage.ToString();
        currentUpOffset = 0;
    }

    private void Update()
    {
        currentUpOffset += _moveUpSpeed * Time.deltaTime;

        transform.position = GameController.Instance.MainCamera.WorldToScreenPoint(_followTarget.position);
        transform.position += Vector3.up * currentUpOffset;

        Color newColor = _txt.color;
        newColor.a -= _fadeSpeed * Time.deltaTime;
        _txt.color = newColor;

        if (_txt.color.a <= 0)
        {
            Destroy(_followTarget.gameObject);
            Destroy(gameObject);
        }
    }
}
