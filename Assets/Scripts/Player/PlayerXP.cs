using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    public int XP;
    public int currentLevel = 1;

    [SerializeField] Slider _xpBar;
    [SerializeField] Text _levelText;

    public DetectXP DetectXP;

    private void Start()
    {
        _xpBar.value = 0;
        _levelText.text = "1";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameController.XP_TAG))
        {
            Destroy(collision.gameObject);
            XP++;
            _xpBar.value = (float)XP / GameInformation.Instance.levelXPs[currentLevel - 1];

            AudioController.Instance.PlayAudio(Audio.PickUpXP);

            if (XP >= GameInformation.Instance.levelXPs[currentLevel - 1])
            {
                GameController.Instance.PopupChooseSkillController.Show();

                XP = 0;
                _xpBar.value = (float)XP / GameInformation.Instance.levelXPs[currentLevel - 1];
                currentLevel++;
                _levelText.text = currentLevel.ToString();
            }
        }
    }
}
