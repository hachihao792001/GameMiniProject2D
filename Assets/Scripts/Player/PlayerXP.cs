using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int XP;
    public int currentLevel = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameInformation.XP_TAG))
        {
            Destroy(collision.gameObject);
            XP++;
            if (XP >= GameInformation.Instance.levelXPs[currentLevel - 1])
            {
                XP = 0;
                currentLevel++;
            }
        }
    }
}
