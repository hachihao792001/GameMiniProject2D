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
    public override void Init(BulletInfo info, Transform target, float bonusDamage)
    {
        base.Init(info, target, bonusDamage);
        startDir = (target.position - transform.position).normalized;

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
        else
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
            enemy.TakeHealth(myInfo.damage + bonusDamage);
        }
    }
}
