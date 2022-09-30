using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler
{

    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private Canvas canvas;
    private Vector3 clampedPosition;
    [SerializeField]
    private RectTransform parentRectTransform;

    public void Start()
    {
        dragRectTransform = GetComponent<RectTransform>();
        clampedPosition = dragRectTransform.localPosition;
    }


    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        ClampToWindow();
    }



    private void ClampToWindow()
    {
        Vector3 pos = dragRectTransform.localPosition;

        Vector3 minPosition = parentRectTransform.rect.min - dragRectTransform.rect.min;
        Vector3 maxPosition = parentRectTransform.rect.max - dragRectTransform.rect.max;

        pos.x = Mathf.Clamp(dragRectTransform.localPosition.x, minPosition.x, maxPosition.x);
        pos.y = Mathf.Clamp(dragRectTransform.localPosition.y, minPosition.y, maxPosition.y);

        dragRectTransform.localPosition = pos;
    }


}
