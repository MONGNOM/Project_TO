using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;


public class Gauge : MonoBehaviour
{
    public Image imageFillAmount;
    public float removeGauge;
    public float addGauge;
    public float gaugeTime;
    public float removegaugeTime;
    public float minReMoveGaugeTime;
    private bool gameOver;
    public float feverTime;
    public float delayTime;


    public void Awake()
    {
        gameOver = false;
        imageFillAmount = GetComponent<Image>();
    }

    void Start()
    {
        imageFillAmount.fillAmount = 0f;
    }
    private void Update()
    {
        if (imageFillAmount.fillAmount >= 1)
        {
            feverTime += Time.deltaTime;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.LeftControl))
        {
            imageFillAmount.fillAmount = 1;
            Debug.Log("Fever����");
        }
       

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
        // ���� �ð� ��ġ ������ ������ ���̴� �� ����
        while (imageFillAmount.fillAmount > 0) 
        {
            Debug.Log("Gauge����");
            imageFillAmount.fillAmount -= removeGauge;
            yield return new WaitForSeconds(gaugeTime);
        }
        //gameOver = true;

    }

}
