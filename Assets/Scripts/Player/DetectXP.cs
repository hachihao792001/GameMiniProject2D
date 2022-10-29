using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectXP : MonoBehaviour
{
    [SerializeField] CircleCollider2D _collider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameController.XP_TAG))
        {
            LerpTowards xpLerpTowards = collision.gameObject.GetComponent<LerpTowards>();
            xpLerpTowards.enabled = true;
            xpLerpTowards.Init(GameController.Instance.Player.transform);
        }
    }

    public void IncreaseRange(float value)
    {
        _collider.radius += value;
    }
}
