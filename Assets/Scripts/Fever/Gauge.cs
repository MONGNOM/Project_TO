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
    private bool gameOver;


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
        if (gameOver) 
        {
            gameOver = false;
            GameManager.instance.GameOver();
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
        // 일정 시간 터치 없을시 게이지 줄이는 것 시작
        while (imageFillAmount.fillAmount > 0) 
        {
            Debug.Log("Gauge감소");
            imageFillAmount.fillAmount -= removeGauge;
            yield return new WaitForSeconds(gaugeTime);
        }
        //gameOver = true;

    }

}
