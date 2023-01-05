using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Skin_index
{
    default_skin = 0, 
    ff_skin1 = 1, 
    ff_skin2 = 2, 
    ff_skin3 = 3,
    prestige_skin1 = 4,
    prestige_skin2 = 5,
    prestige_skin3 = 6,
    new_year_skin1 = 7, 
    new_year_skin2 = 8     
}




public class ShopButtonController : MonoBehaviour
{
    public Skin_index skin_idx;
    //[SerializeField] bool isEquipped;
    //[SerializeField] GameObject lockIcon;
    [SerializeField] bool isUnlocked;
    [SerializeField] Button button;






    

    public void SetData(bool isUnlocked/*, bool isEquipped*/)
    {
        this.isUnlocked = isUnlocked;
        //lockIcon.SetActive(!isUnlocked);

        //this.isEquipped = isEquipped;
        //lockIcon.SetActive(!isUnlocked);
    }

    

    


    /*public void playGame()
    {
        if (isUnlocked)
        {
            // PlayerPrefs.SetInt("skin_idx", (int)skin_idx);
            //SceneManager.LoadScene("Game");
        }
    }*/

    public void Click()
    {
        button.onClick.Invoke();
    }
}
