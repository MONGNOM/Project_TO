using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchScreen : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private Gauge gauge;
    [SerializeField] private PointChange pointChange;

    public TextMeshProUGUI text;
    public int point;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        pointChange.PointSpriteChange();
        gauge.AddGauge();
        Pointup();
        Debug.Log("point+1");
    }

    private void Pointup()
    {
        point += 1;
        // 점수 이미지 변경하는구현 
    }

    public void PointUp(int p)
    {
        point += p;
    }

    public void TextPoint()
    {
        text.text = point.ToString();
    }

}
