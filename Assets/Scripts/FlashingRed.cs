using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlashingRed : MonoBehaviour
{
    SpriteRenderer _sr;
    float delayBetweenFlash;
    int flashCount;
    float tick = 0;

    private void Start()
    {
        flashCount = 0;
        _sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (flashCount <= 0)
        {
            _sr.color = Color.white;
            return;
        }

        tick += Time.deltaTime;
        if (tick >= delayBetweenFlash)
        {
            _sr.color = _sr.color == Color.white ? Color.red : Color.white;

            flashCount--;
            tick = 0;
        }
    }

    public void DoFlash(float delayBetweenFlash = 0.05f, int flashCount = 6)
    {
        this.delayBetweenFlash = delayBetweenFlash;
        this.flashCount = flashCount;
    }

}
