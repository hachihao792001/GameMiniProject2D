using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public RectTransform Canvas;

    public RectTransform StageContainer;
    public StageButtonController[] StageButtonList;
    public Button[] buttons;
    [SerializeField] HorizontalLayoutGroup stageContainerLayout;

    float[] stageContainerPositions;
    float stageButtonWidth = 700.3167f;
    private int index = 0;

    Vector2 targetAnchoredPosition;

    bool isGoingToTarget;

    private void Start()
    {
        stageContainerLayout.spacing = Canvas.rect.width * 372.4f / 1080f;
        stageContainerLayout.padding.left = stageContainerLayout.padding.right = Mathf.RoundToInt(Canvas.rect.width / 2 - stageButtonWidth / 2);

        stageContainerPositions = new float[StageButtonList.Length];

        for (int i = 0; i < stageContainerPositions.Length; i++)
        {
            stageContainerPositions[i] = -i * (stageContainerLayout.spacing + stageButtonWidth);
        }
        StageContainer.anchoredPosition = new Vector2(stageContainerPositions[0], 0);

        LayoutRebuilder.ForceRebuildLayoutImmediate(StageContainer);
    }
    private void OnEnable()
    {
        for (int i = 0; i < StageButtonList.Length; i++)
        {
            StageButtonList[i].SetData(DataManager.IsStageUnlocked(StageButtonList[i].stage));
        }
    }

    public void scroll(bool isLeft)
    {
        index += isLeft ? -1 : 1;
        if (index < 0) index = 0;
        if (index >= StageContainer.childCount) index = StageContainer.childCount - 1;

        setTargetAnchoredPosition(new Vector2(stageContainerPositions[index], 0));
        buttons[0].interactable = index != 0;
        buttons[1].interactable = index != StageContainer.childCount - 1;

    }

    float tick = 0;
    Vector2 previousAnchoredPosition;
    void setTargetAnchoredPosition(Vector2 target)
    {
        tick = 0;
        previousAnchoredPosition = StageContainer.anchoredPosition;
        targetAnchoredPosition = target;
        isGoingToTarget = true;
    }

    void Update()
    {
        if (isGoingToTarget)
        {
            tick += 3 * Time.deltaTime;
            if (tick < 1)
            {
                StageContainer.anchoredPosition = Vector3.Lerp(previousAnchoredPosition, targetAnchoredPosition, tick);
            }
            else
            {
                StageContainer.anchoredPosition = targetAnchoredPosition;
                isGoingToTarget = false;
            }
        }

        if (DataManager.IsTutorialShown)
        {
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
                StageButtonList[index].Click();
            }
        }
    }
}
