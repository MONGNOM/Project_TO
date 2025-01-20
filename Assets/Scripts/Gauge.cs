using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gauge : MonoBehaviour
{
    private Image imageFillAmount;
    public float removeGauge;
    public float addGauge;
    public float gaugeTime;
    public float removegaugeTime;
    public float minReMoveGaugeTime;


    public void Awake()
    {
        imageFillAmount = GetComponent<Image>();
    }

    void Start()
    {
        StartCoroutine(RemoveGauge());
    }

    public void AddGauge()
    {
        imageFillAmount.fillAmount += addGauge;
    }

    public void RemoveGaugeTimeFast()
    {
        if (minReMoveGaugeTime > removegaugeTime)
        {
            removegaugeTime = minReMoveGaugeTime;
            return;
        }

        gaugeTime -= removegaugeTime;
    }

    IEnumerator RemoveGauge()
    {
        while (true) 
        {
            Debug.Log("Gauge°¨¼Ò");
            imageFillAmount.fillAmount -= removeGauge;
            yield return new WaitForSeconds(gaugeTime);
        }
    }

}
