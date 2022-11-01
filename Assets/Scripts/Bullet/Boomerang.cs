using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Bullet
{
    [SerializeField] float firstDuration, secondDuration;
    [SerializeField] bool doneStartDir;
    [SerializeField] float initialForce, goBackForce;

    [SerializeField] float rotateSpeed;
    float tick = 0;

    Vector3 startDir;
    public override void Init(BulletInfo info, Vector3 targetPos, BulletBonusStat bonusStat)
    {
        base.Init(info, targetPos, bonusStat);
        startDir = (targetPos - transform.position).normalized;

        rb.AddForce(startDir * initialForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        tick += Time.deltaTime;
        if (!doneStartDir)
        {
            if (tick >= firstDuration)
            {
                tick = 0;
                doneStartDir = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (doneStartDir)
        {
            if (tick < secondDuration)
            {
                rb.AddForce(-startDir * goBackForce, ForceMode2D.Force);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeHealth(getFinalDamage());
        }
    }
}
