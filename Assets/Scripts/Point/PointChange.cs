using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class PointChange : MonoBehaviour
{
    [SerializeField] private Sprite[] pointSprites;
    [SerializeField] private Image[] numberImage;
    [SerializeField] private UnderGround floor;
    [SerializeField] private TextController textController;

    private void Start()
    {
        for (int i = 1; i < numberImage.Length; i++) // 맨 처음 10 100 자리 숫자 꺼주기 
        {
            numberImage[i].gameObject.SetActive(false);
        }

    }

    public void PointSpriteChange()
    {
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {

        int tempPoint = floor.countFloor;
        for (int i = 0; i < numberImage.Length; i++)
        {
            int digit = tempPoint % 10;
            numberImage[i].sprite = pointSprites[digit];
            tempPoint /= 10;

        }

        if (floor.countFloor == 10 && numberImage[1].sprite == pointSprites[1]) // 10의자리 켜주기
        {
            numberImage[1].gameObject.SetActive(true);
            textController.TextPosChange();
        }

        if (floor.countFloor == 100 && numberImage[2].sprite == pointSprites[1]) // 100의 자리 켜주기 
        {
            numberImage[2].gameObject.SetActive(true);
            textController.TextPosChange();
        }


        Debug.Log("imageChange");
    }
}
