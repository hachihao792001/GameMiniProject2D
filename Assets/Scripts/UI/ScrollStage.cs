using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollStage : MonoBehaviour
{
    public RectTransform stageList;
    public Button[] buttons;
    private float distance = 1063.25f;
    private int index = 0;

    Vector2 targetAnchoredPosition;

    public void scroll(bool isLeft)
    {
        index += isLeft ? -1 : 1;
        if (index < 0) index = 0;
        if (index >= stageList.childCount) index = stageList.childCount - 1;

        targetAnchoredPosition = new Vector3(-distance * index, 0, 0);
        buttons[0].interactable = index != 0;
        buttons[1].interactable = index != stageList.childCount - 1;
    }

    void Update()
    {
        if (Mathf.Abs(stageList.anchoredPosition.x - targetAnchoredPosition.x) > 0.1f)
        {
            stageList.anchoredPosition = Vector3.Lerp(stageList.anchoredPosition, targetAnchoredPosition, Time.deltaTime * 10f);
        }
    }
}
