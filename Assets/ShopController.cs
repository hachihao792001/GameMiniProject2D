using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public RectTransform Canvas;

    public RectTransform ShopContainer;
    public ShopButtonController[] ShopButtonList;
    public Button[] buttons;
    [SerializeField] HorizontalLayoutGroup shopContainerLayout;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] TextMeshProUGUI goldOwned;
    [SerializeField] Button buyskin;
    [SerializeField] Button equipskin;
    [SerializeField] Button equippedskin;
    //[SerializeField] HorizontalLayoutGroup shopContainerLayout;
    [SerializeField] GameObject buyConfirm;


    [SerializeField] Button buySkinConfirm;
    [SerializeField] Button cancelBuySkinConfirm;
    [SerializeField] Button okBtn;

    [SerializeField] GameObject sceneSuccess;
    [SerializeField] GameObject sceneFail;


    float[] shopContainerPositions;
    float shopButtonWidth = 700.3167f;
    private int index = 0;

    Vector2 targetAnchoredPosition;
    public int[] skinPrize = { 0, 9, 18, 27, 36, 54, 72, 108, 135 };
    bool isGoingToTarget;

    private void Start()
    {

        goldOwned.text = DataManager.Money.ToString();
        shopContainerLayout.spacing = Canvas.rect.width * 372.4f / 1080f;
        shopContainerLayout.padding.left = shopContainerLayout.padding.right = Mathf.RoundToInt(Canvas.rect.width / 2 - shopButtonWidth / 2);

        shopContainerPositions = new float[ShopButtonList.Length];

        for (int i = 0; i < shopContainerPositions.Length; i++)
        {
            shopContainerPositions[i] = -i * (shopContainerLayout.spacing + shopButtonWidth);
        }
        ShopContainer.anchoredPosition = new Vector2(shopContainerPositions[0], 0);
        int last = DataManager.EquippedSkinIndex;
        //index = last;
        //ShopButtonList[last].showInteractiveBtn();
        LayoutRebuilder.ForceRebuildLayoutImmediate(ShopContainer);
        print(DataManager.Money);
        showInteractiveBtn(0);
    }

    public void turnOffInteractiveBtn()
    {
        //if (buyskin.gameObject.activeSelf)
        buyskin.gameObject.SetActive(false);
        //if (equipskin.gameObject.activeSelf) 
        equipskin.gameObject.SetActive(false);
        //if (equippedskin.gameObject.activeSelf) 
        equippedskin.gameObject.SetActive(false);
    }

    public void showInteractiveBtn(Skin_index i)
    {
        turnOffInteractiveBtn();
        bool isUnlocked = DataManager.IsSkinUnlocked(i);
        if (!isUnlocked)
        {
            buyskin.gameObject.SetActive(true);
            // int gold = PlayerPrefs.GetInt("Money");

            textMesh.text = skinPrize[index].ToString();
        }
        else if (index == DataManager.EquippedSkinIndex)
        {
            equippedskin.gameObject.SetActive(true);
        }
        else
            equipskin.gameObject.SetActive(true);
    }
    private void OnEnable()
    {
        for (int i = 0; i < ShopButtonList.Length; i++)
        {
            ShopButtonList[i].SetData(DataManager.IsSkinUnlocked(ShopButtonList[i].skin_idx));
        }
    }

    public void scroll(bool isLeft)
    {
        turnOffInteractiveBtn();

        index += isLeft ? -1 : 1;
        if (index < 0) index = 0;
        if (index >= ShopContainer.childCount) index = ShopContainer.childCount - 1;

        setTargetAnchoredPosition(new Vector2(shopContainerPositions[index], 0));
        buttons[0].interactable = index != 0;
        buttons[1].interactable = index != ShopContainer.childCount - 1;

        showInteractiveBtn((Skin_index)index);

    }
    public void confirmBuySkin()
    {
        int gold = DataManager.Money;
        int skin_prize = skinPrize[index];
        print(gold);
        if (gold >= skin_prize)
        {
            print(1);
            DataManager.Money = gold - skin_prize;
            goldOwned.text = DataManager.Money.ToString();
            sceneSuccess.SetActive(true);
            sceneFail.SetActive(false);
        }
        else
        {
            print(0);
            sceneSuccess.SetActive(false);
            sceneFail.SetActive(true);
        }
    }

    public void confirmSuccessful()
    {
        DataManager.UnlockSkin((Skin_index)index);
        turnOffInteractiveBtn();
        equipskin.gameObject.SetActive(true);
        sceneSuccess.SetActive(false);
        sceneFail.SetActive(false);
    }

    /*public void buySkin()
    {
   
        
    }*/

    public void equipSkin()
    {
        DataManager.EquippedSkinIndex = index;
        turnOffInteractiveBtn();
        equippedskin.gameObject.SetActive(true);
        //System.Console.WriteLine(PlayerPrefs.GetInt("EquippedSkinIndex").ToString());

        Debug.Log("WeaponNum = " + DataManager.EquippedSkinIndex.ToString());
    }


    float tick = 0;
    Vector2 previousAnchoredPosition;
    void setTargetAnchoredPosition(Vector2 target)
    {
        tick = 0;
        previousAnchoredPosition = ShopContainer.anchoredPosition;
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
                ShopContainer.anchoredPosition = Vector3.Lerp(previousAnchoredPosition, targetAnchoredPosition, tick);
            }
            else
            {
                ShopContainer.anchoredPosition = targetAnchoredPosition;
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
                ShopButtonList[index].Click();
            }
        }
    }
}
