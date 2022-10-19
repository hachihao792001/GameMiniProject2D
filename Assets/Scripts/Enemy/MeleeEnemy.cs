using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] float _speed;

    Player player;

    private void Start()
    {
        player = GameController.Instance.Player;
    }

    void Update()
    {
        transform.Translate((player.transform.position - transform.position).normalized * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
