using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class TextController : MonoBehaviour
{
    public RectTransform textrect;

    private void Awake()
    {
        textrect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        textrect.anchoredPosition = new Vector2(0, -340);
    }

    public void TextPosChange()
    {
        Vector2 pos = textrect.anchoredPosition;
        textrect.anchoredPosition = new Vector2(pos.x + 100, textrect.anchoredPosition.y);
    }
}
