using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] RectTransform _joyStickHandle;
    [SerializeField] float _joyStickHandleMaxDistance;
    private Vector3 _joyStickHandleOriginPos;

    bool locking;

    public Vector2 Input => (_joyStickHandle.position - _joyStickHandleOriginPos) / _joyStickHandleMaxDistance;

    private void Start()
    {
        _joyStickHandleOriginPos = _joyStickHandle.position;
    }

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData)
    {
        if (locking) return;
        _joyStickHandle.position = eventData.position;
        ClampJoyStickHandle();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _joyStickHandle.position = _joyStickHandleOriginPos;
    }

    private void ClampJoyStickHandle()
    {
        if (Vector3.Distance(_joyStickHandle.position, _joyStickHandleOriginPos) > _joyStickHandleMaxDistance)
        {
            _joyStickHandle.position = _joyStickHandleOriginPos + (_joyStickHandle.position - _joyStickHandleOriginPos).normalized * _joyStickHandleMaxDistance;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (locking) return;
        _joyStickHandle.position = eventData.position;
        ClampJoyStickHandle();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joyStickHandle.position = _joyStickHandleOriginPos;
    }

    public void Lock() => locking = true;
    public void Unlock() => locking = false;
}