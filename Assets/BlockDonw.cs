using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDonw : MonoBehaviour
{
    [Header("↓관리")]
    [Header("영향 층 수")] [SerializeField] private float floorCounter;
    [Header("내려오는 시간")] [SerializeField] private float downTime;
    [Header("내려오는 시간 - mindownTime [값이 클수록 빠르게 내려옴]")] [SerializeField] private float mindownTime;
    [Header("내려가는 높이")] [SerializeField] private float downHeight;
    [Header("내려가는 높이 + mindownHeight [값이 클수록 많이 내려옴]")] [SerializeField] private float mindownHeight;

    [Header("↓디버깅 값========================")]
    [Header("층 수")][SerializeField] private float floorCount;
    [SerializeField] private Vector2 pos;
    [SerializeField] Vector2 prePos;

    void Start()
    {
        prePos = gameObject.transform.position;
        StartCoroutine(DownBlock());
    }

    public void PreviousPos()
    {
        Debug.Log("prePos: " + prePos);
        pos = prePos;
        floorCount++;
        if (floorCount >= floorCounter)
        {
            floorCount = 0;
            downTime -= mindownTime;
            downHeight += mindownHeight;
            MinimumCondition();
        }
    }

    public void MinimumCondition()
    { 
        // 최소한 값 정해놓기
        if (0 >= downTime - mindownTime)
        {
            downTime = 0.1f;
        }

        if (downHeight + mindownHeight >= 3)
        {
            downHeight = 3; 
        }
    }

    IEnumerator DownBlock()
    {
        pos = prePos; 
        Debug.Log("DownPos: " + pos);

        while (pos.y > 4)
        {
            Debug.Log("DownBlock++");
            gameObject.transform.position = new Vector2(pos.x, pos.y -= downHeight);
            yield return new WaitForSeconds(downTime);
        }

       // GameManager.instance.GameOver();
    }



}
