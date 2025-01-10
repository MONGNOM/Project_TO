using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public float speed;
    public float destoryTime;
    public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        destoryTime += Time.deltaTime;
        transform.position += Vector3.up * Time.deltaTime * speed;

        if (destoryTime >= 0.3)
        {
            destoryTime = 0;
            Destroy(gameObject);
        }
    }

    public void GaugeText(float point)
    {
        text.color = Color.white;
        text.text = "Gauge +"+point.ToString();
    }

    public void FeverGaugeText(float point)
    {
        text.color = new Color(0.9056604f, 0.8073284f, 0.4314703f, 1);
        text.text = "Gauge +" + point.ToString();
    }



}
