using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemyPrefabs;

    [SerializeField] float nearX, farX, nearY, farY;
    [SerializeField] float minDelay, maxDelay;
    float tick = 0;
    float currentDelay = 0;

    private void Start()
    {
        GetNewDelay();
    }

    private void Update()
    {
        tick += Time.deltaTime;
        if (tick >= currentDelay)
        {
            bool top = Random.Range(0, 2) == 0;
            bool right = Random.Range(0, 2) == 0;

            Vector2 newEnemyPos = Vector2.zero;

            newEnemyPos.y = GameController.Instance.Player.transform.position.y + (top ? 1 : -1) * Random.Range(nearY, farY);
            newEnemyPos.x = GameController.Instance.Player.transform.position.x + (right ? 1 : -1) * Random.Range(nearX, farX);

            int newEnemyTypeIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[newEnemyTypeIndex], newEnemyPos, Quaternion.identity);

            GetNewDelay();
            tick = 0;
        }
    }

    void GetNewDelay()
    {
        currentDelay = Random.Range(minDelay, maxDelay);
    }
}
