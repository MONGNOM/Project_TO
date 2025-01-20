using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class PointChange : MonoBehaviour
{
    [SerializeField] private Sprite[] pointSprites;
    [SerializeField] private Image[] numberImage;
    [SerializeField] private TouchScreen touch;

    [SerializeField] private Sprite zero;


    private void Start()
    {
        for (int i = 0; i < numberImage.Length; i++)
        {
            numberImage[i].sprite = zero;
        }
    }

    public void PointSpriteChange()
    {


        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        int tempPoint = touch.Point;
        for (int i = 0; i < numberImage.Length; i++)
        {
            int digit = tempPoint % 10;
            numberImage[i].sprite = pointSprites[digit];
            tempPoint /= 10;

        }

       
        Debug.Log("imageChange");
    }
}
