using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gauge : MonoBehaviour
{
    private Image imageFillAmount;
    public float removeGauge;
    public float gaugeTime;

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
        imageFillAmount.fillAmount += 0.01f;
    }

    IEnumerator RemoveGauge()
    {
        while (true) 
        {
            Debug.Log("Gauge����");
            imageFillAmount.fillAmount -= removeGauge;
            yield return new WaitForSeconds(gaugeTime);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("�ӵ�����");
            gaugeTime -= 0.1f;
        }

    }

}
