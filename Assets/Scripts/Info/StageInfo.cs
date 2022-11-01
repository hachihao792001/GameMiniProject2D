using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct EnemySpawningInfo
{
    public EnemyType enemyType;
    public int rateWeight;    //ti trong xuat hien
    public int minLevel;
}

[CreateAssetMenu(fileName = "StageSpawningInfo", menuName = "ScriptableObjects/StageSpawningInfo")]
public class StageInfo : ScriptableObject
{
    public Stage Stage;
    public string stageName;
    public List<EnemySpawningInfo> EnemySpawningInfos;

    public int CalculateSumWeight(List<EnemySpawningInfo> spawningInfos)
    {
        int sumWeight = 0;
        for (int i = 0; i < spawningInfos.Count; i++)
        {
            sumWeight += spawningInfos[i].rateWeight;
        }
        return sumWeight;

    }

    public int[] CalculateWeightSumArray(List<EnemySpawningInfo> spawningInfos)
    {
        int[] result = new int[spawningInfos.Count];
        result[0] = spawningInfos[0].rateWeight;
        for (int i = 1; i < result.Length; i++)
        {
            result[i] = result[i - 1] + spawningInfos[i].rateWeight;
        }
        return result;
    }

    public List<EnemySpawningInfo> GetSpawnableEnemies(int level)
    {
        List<EnemySpawningInfo> result = new List<EnemySpawningInfo>();
        for (int i = 0; i < EnemySpawningInfos.Count; i++)
        {
            if (level >= EnemySpawningInfos[i].minLevel)
            {
                result.Add(EnemySpawningInfos[i]);
            }
        }
        return result;
    }
}