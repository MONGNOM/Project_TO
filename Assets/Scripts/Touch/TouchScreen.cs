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
        /*if (gaugePoint >= 100) 100���� �ö󰥼��� ������ �������� �ð� ����
        {
            gauge.RemoveGaugeTimeFast();
            gaugePoint = 0;
        }*/

        //Pointup();
        //gauge.AddGauge();
        //pointChange.PointSpriteChange(); // ����Ʈ �̹��� ��ü
        Debug.Log("��� ��ġ ");
         
    }

    private void Pointup()
    {
        Point++;
        gaugePoint++;
    }

}
