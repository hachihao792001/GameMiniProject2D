using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHelper : Helper
{
    public List<Sword> Swords;
    [SerializeField] Sword _additionalSword;
    [SerializeField] float _rotateSpeed;
    [SerializeField] float _swordDistanceFromCenter;

    Vector2 rotatingVector;

    private void Start()
    {
        rotatingVector = Vector2.up;

        for (int i = 0; i < Swords.Count; i++)
        {
            Swords[i].OnHitEnemy = OnHitEnemy;
        }

        ArrangeSwordsBaseOnNumber();
    }

    private void Update()
    {
        rotatingVector = Quaternion.Euler(0, 0, _rotateSpeed * Time.deltaTime) * rotatingVector;
        transform.up = rotatingVector;
    }

    void OnHitEnemy(Enemy enemy)
    {
        enemy.TakeHealth(getFinalDamage());
    }

    public void AddOneMoreSword()
    {
        _additionalSword.gameObject.SetActive(true);
        Swords.Add(_additionalSword);
        ArrangeSwordsBaseOnNumber();
    }

    void ArrangeSwordsBaseOnNumber()
    {
        int swordCount = Swords.Count;
        float degreeBetweenSwords = 360f / swordCount;

        Vector3 currentDir = Vector3.up;
        for (int i = 0; i < swordCount; i++)
        {
            Swords[i].transform.position = transform.position + currentDir * _swordDistanceFromCenter;
            Swords[i].transform.up = currentDir;
            currentDir = Quaternion.Euler(0, 0, degreeBetweenSwords) * currentDir;
        }
    }
}
