using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchScreen : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private Gauge gauge;
    [SerializeField] private PointChange pointChange;

    private int point;
    private int gaugePoint;
    public int Point { get { return point; } private set { point = value; } }
    
    

    public void OnPointerClick(PointerEventData eventData)
    {
        /*if (gaugePoint >= 100) 100점씩 올라갈수록 게이지 떨어지는 시간 증가
        {
            gauge.RemoveGaugeTimeFast();
            gaugePoint = 0;
        }*/

        //Pointup();
        //gauge.AddGauge();
        //pointChange.PointSpriteChange(); // 포인트 이미지 교체
        Debug.Log("블록 터치 ");
         
    }

    private void Pointup()
    {
        Point++;
        gaugePoint++;
    }

}
