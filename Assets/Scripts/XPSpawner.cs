using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPSpawner : MonoBehaviour
{
    [SerializeField] float nearX, farX, nearY, farY;
    [SerializeField] float minDelay, maxDelay;
    float tick = 0;
    float currentDelay = 0;

    // Update is called once per frame
    void Update()
    {
        tick += Time.deltaTime;
        if (tick >= currentDelay)
        {
            bool top = Random.Range(0, 2) == 0;
            bool right = Random.Range(0, 2) == 0;

            Vector2 newXPPos = Vector2.zero;

            newXPPos.y = GameController.Instance.Player.transform.position.y + (top ? 1 : -1) * Random.Range(nearY, farY);
            newXPPos.x = GameController.Instance.Player.transform.position.x + (right ? 1 : -1) * Random.Range(nearX, farX);

            Instantiate(GameController.Instance.XPPrefab, newXPPos, Quaternion.identity).Init(1);

            GetNewDelay();
            tick = 0;
        }
    }
    private void Start()
    {
        GetNewDelay();
    }
    void GetNewDelay()
    {
        currentDelay = Random.Range(minDelay, maxDelay);
    }
}
