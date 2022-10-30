using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public RectTransform StageContainer;
    public Button[] StageButtonList;
    public Button[] buttons;
    private float distance = 1071f;
    private int index = 0;

    Vector2 targetAnchoredPosition;

    public void scroll(bool isLeft)
    {
        index += isLeft ? -1 : 1;
        if (index < 0) index = 0;
        if (index >= StageContainer.childCount) index = StageContainer.childCount - 1;

        targetAnchoredPosition = new Vector3(-distance * index, 0, 0);
        buttons[0].interactable = index != 0;
        buttons[1].interactable = index != StageContainer.childCount - 1;
    }

    void Update()
    {
        if (Mathf.Abs(StageContainer.anchoredPosition.x - targetAnchoredPosition.x) > 0.1f)
        {
            StageContainer.anchoredPosition = Vector3.Lerp(StageContainer.anchoredPosition, targetAnchoredPosition, Time.deltaTime * 10f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            buttons[0].onClick.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            buttons[1].onClick.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            StageButtonList[index].onClick.Invoke();
        }
    }
}
