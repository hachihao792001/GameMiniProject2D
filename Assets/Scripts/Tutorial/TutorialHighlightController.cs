using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHighlightController : MonoBehaviour
{
    Transform target;
    public IEnumerator Show(Transform target)
    {
        gameObject.SetActive(true);

        this.target = target;
        transform.position = Camera.main.WorldToScreenPoint(target.position);

        yield return new WaitUntil(() => !gameObject.activeSelf);
    }

    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(target.position);
    }

    public void FakeButtonOnClick()
    {
        gameObject.SetActive(false);
    }
}
