using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWallsController : MonoBehaviour
{
    [SerializeField] BoxCollider2D top, bottom, left, right;

    private void Start()
    {
        float scaleFactor = (float)Screen.width / Screen.height > 1.5f ? 0.5f : 1f;
        Camera mainCamera = GameController.Instance.MainCamera;

        float height = Camera.main.orthographicSize * 2.0f * scaleFactor;
        float width = height * Screen.width / Screen.height;

        Rect canvasRect = (GameController.Instance.Canvas as RectTransform).rect;

        top.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)) * scaleFactor
           + Vector3.up * top.bounds.extents.y;
        top.size = new Vector2(width, top.size.y);

        bottom.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)) * scaleFactor
           - Vector3.up * bottom.bounds.extents.y;
        bottom.size = new Vector2(width, bottom.size.y);

        left.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0)) * scaleFactor
           - Vector3.right * left.bounds.extents.x;
        left.size = new Vector2(left.size.x, height);

        right.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0)) * scaleFactor
           + Vector3.right * right.bounds.extents.x;
        right.size = new Vector2(right.size.x, height);
    }
}
