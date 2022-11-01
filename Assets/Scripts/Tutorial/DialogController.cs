using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    [SerializeField] TMP_Text txtDialogContent;
    public IEnumerator Show(DialogInfo info, bool useAlternative)
    {
        gameObject.SetActive(true);

        txtDialogContent.text = useAlternative ? info.alternativeDialogContent : info.dialogContent;

        yield return new WaitUntil(() => !gameObject.activeSelf);
    }

    public void OnClick()
    {
        gameObject.SetActive(false);
    }
}
