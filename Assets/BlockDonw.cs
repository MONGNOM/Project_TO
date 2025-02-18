using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDonw : MonoBehaviour
{
    [Header("�����")]
    [Header("���� �� ��")] [SerializeField] private float floorCounter;
    [Header("�������� �ð�")] [SerializeField] private float downTime;
    [Header("�������� �ð� - mindownTime [���� Ŭ���� ������ ������]")] [SerializeField] private float mindownTime;
    [Header("�������� ����")] [SerializeField] private float downHeight;
    [Header("�������� ���� + mindownHeight [���� Ŭ���� ���� ������]")] [SerializeField] private float mindownHeight;

    [Header("������ ��========================")]
    [Header("�� ��")][SerializeField] private float floorCount;
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
        // �ּ��� �� ���س���
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
