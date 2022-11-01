using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Enemy> enemyPrefabs;

    [SerializeField] float nearX, farX, nearY, farY;
    [SerializeField] float minDelay, maxDelay;
    float tick = 0;
    float currentDelay = 0;

    [SerializeField] float _delayDecreaseRate;

    private void Awake()
    {
        GameController.Instance.onPlayerLevelUp += OnPlayerLevelUp;
    }

    private void OnPlayerLevelUp()
    {
        minDelay -= _delayDecreaseRate;
        maxDelay -= _delayDecreaseRate;
    }

    private void Start()
    {
        GetNewDelay();
    }

    private void Update()
    {
        if (!TutorialManager.IsTutorialShown)
            return;

        tick += Time.deltaTime;
        if (tick >= currentDelay)
        {
            bool top = Random.Range(0, 2) == 0;
            bool right = Random.Range(0, 2) == 0;

            Vector2 newEnemyPos = Vector2.zero;

            newEnemyPos.y = GameController.Instance.Player.transform.position.y + (top ? 1 : -1) * Random.Range(nearY, farY);
            newEnemyPos.x = GameController.Instance.Player.transform.position.x + (right ? 1 : -1) * Random.Range(nearX, farX);

            EnemyType newEnemyType = GetRandomEnemy();
            Instantiate(enemyPrefabs.Find(x => x.enemyType == newEnemyType), newEnemyPos, Quaternion.identity);

            GetNewDelay();
            tick = 0;
        }
    }

    void GetNewDelay()
    {
        currentDelay = Random.Range(minDelay, maxDelay);
    }
    public EnemyType GetRandomEnemy()
    {
        StageInfo stageInfo = GameController.Instance.CurrentStageInfo;
        List<EnemySpawningInfo> spawnableEnemies = stageInfo.GetSpawnableEnemies(GameController.Instance.Player.PlayerXP.currentLevel);
        int sumWeight = stageInfo.CalculateSumWeight(spawnableEnemies);
        int[] weightSumArray = stageInfo.CalculateWeightSumArray(spawnableEnemies);

        int random = Random.Range(1, sumWeight + 1);
        for (int i = 0; i < weightSumArray.Length; i++)
        {
            if (random <= weightSumArray[i])
            {
                return spawnableEnemies[i].enemyType;
            }
        }
        return EnemyType.None;
    }
}
