using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLevelDisplayer : MonoBehaviour
{
    [SerializeField] List<GameObject> _stars;

    public void SetLevel(int level)
    {
        for (int i = 0; i < _stars.Count; i++)
        {
            _stars[i].SetActive(i + 1 <= level);
        }
    }
}
