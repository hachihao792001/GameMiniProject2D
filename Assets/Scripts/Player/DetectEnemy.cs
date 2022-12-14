using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    public List<Transform> _enemiesInZone;

    public Transform nearestEnemy;

    [SerializeField] CircleCollider2D _collider;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateNearestEnemy), 0, 1f);
    }

    void UpdateNearestEnemy()
    {
        if (_enemiesInZone.Count == 0)
        {
            nearestEnemy = null;
            return;
        }
        for (int i = _enemiesInZone.Count - 1; i >= 0; i--)
        {
            if (_enemiesInZone[i] == null)
                _enemiesInZone.RemoveAt(i);
        }
        if (_enemiesInZone.Count == 0)
        {
            nearestEnemy = null;
            return;
        }

        int nearestEnemyIndex = 0;
        for (int i = 1; i < _enemiesInZone.Count; i++)
        {
            if (Vector2.Distance(transform.position, _enemiesInZone[i].position) <
                Vector2.Distance(transform.position, _enemiesInZone[nearestEnemyIndex].position))
            {
                nearestEnemyIndex = i;
            }
        }

        nearestEnemy = _enemiesInZone[nearestEnemyIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameController.ENEMY_TAG) && !_enemiesInZone.Contains(collision.transform))
        {
            _enemiesInZone.Add(collision.transform);
            UpdateNearestEnemy();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameController.ENEMY_TAG))
        {
            _enemiesInZone.Remove(collision.transform);
            UpdateNearestEnemy();
        }
    }

    public void IncreaseRange(float value)
    {
        _collider.radius += value;
    }
}
