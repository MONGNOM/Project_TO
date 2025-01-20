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
    private int point;
    private int gaugePoint;
    public int Point { get { return point; } private set { point = value; } }
    
    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gaugePoint >= 100)
        {
            gauge.RemoveGaugeTimeFast();
            gaugePoint = 0;
        }
        pointChange.PointSpriteChange();
        gauge.AddGauge();
        Pointup();
        Debug.Log("point+1");
    }

    private void Pointup()
    {
        Point++;
        gaugePoint++;
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
