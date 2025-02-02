using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleText : MonoBehaviour
{
    TextMeshProUGUI text;
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
        text.rectTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Debug.Log("1");
        yield return new WaitForSeconds(time += Time.deltaTime);
        text.rectTransform.localScale = new Vector3(1, 1, 1);
        Debug.Log("2");

       /* while (true)
        {
          
        }*/

    }
}
