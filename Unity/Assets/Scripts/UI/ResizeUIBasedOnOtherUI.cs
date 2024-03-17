using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeUIBasedOnOtherUI : LayoutGroup
{
    [SerializeField] RectTransform otherRectTransform;
    float originalY;

    public override void CalculateLayoutInputVertical()
    {
        
    }

    public override void SetLayoutHorizontal()
    {
        
    }

    public override void SetLayoutVertical()
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, originalY - otherRectTransform.sizeDelta.y - padding.bottom + padding.top);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, padding.top);
    }

    protected override void Awake()
    {
        originalY = rectTransform.sizeDelta.y;
    }
}
