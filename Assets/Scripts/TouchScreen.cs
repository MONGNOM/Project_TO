using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchScreen : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int point;

    public void PointUp(int p)
    {
        point += p;
    }

    public void TextPoint()
    {
        text.text = point.ToString();
    }

}
