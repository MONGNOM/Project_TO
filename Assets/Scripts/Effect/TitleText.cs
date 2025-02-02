using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleText : MonoBehaviour
{
    TextMeshProUGUI text;
    public float maxScale;
    public float minScale;
    public int speed;
    public float time;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        StartCoroutine(TextScaleChange());
    }

    IEnumerator TextScaleChange()
    {
        while (true)
        {
            // �۾� �۾���
            while (time > 0)
            {
                time -= Time.deltaTime * speed;
                float scale = Mathf.Lerp(minScale, maxScale, time);
                text.rectTransform.localScale = new Vector3(scale, scale, 1);
                yield return null;

            }

            // �۾� Ŀ��
            while (time < 1)
            {
                time += Time.deltaTime * speed;
                float scale = Mathf.Lerp(minScale, maxScale, time);
                text.rectTransform.localScale = new Vector3(scale, scale, 1);
                yield return null;
            }
        }
    }
}
