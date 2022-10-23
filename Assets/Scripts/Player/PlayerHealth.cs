using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _delayBetweenTakingDamage;
    float tick = 0;
    bool canTakeDamage = true;

    public float FullHealth = 100;
    public float currentHealth;

    [SerializeField] Slider _healthBar;

    [SerializeField] FlashingRed _flashingRed;

    private void Start()
    {
        currentHealth = FullHealth;
        _healthBar.value = currentHealth / FullHealth;
    }

    private void Update()
    {
        if (!canTakeDamage)
        {
            tick += Time.deltaTime;
            if (tick >= _delayBetweenTakingDamage)
            {
                canTakeDamage = true;
                tick = 0;
            }
        }
    }

    public void TakeHealth(float h)
    {
        if (canTakeDamage)
        {
            currentHealth -= h;
            if (currentHealth < 0)
                currentHealth = 0;

            _healthBar.value = currentHealth / FullHealth;

            canTakeDamage = false;

            _flashingRed.DoFlash();
            GameController.Instance.DamageTextController.SpawnNewText(transform.position, h);

            if (currentHealth == 0)
            {
                //Lose
            }
        }
    }

    public void AddHealth(float h)
    {
        currentHealth += h;
        if (currentHealth > FullHealth)
            currentHealth = FullHealth;

        _healthBar.value = currentHealth / FullHealth;
    }
}
