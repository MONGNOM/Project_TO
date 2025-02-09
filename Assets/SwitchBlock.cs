using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchBlock : MonoBehaviour
{
    [Header("�ö󰡴µ� �ɸ��� �ð�")]
    [SerializeField] float posUpTime;

    [Header("�ö���� �ִ� �ð�")]
    [SerializeField] float checkTime;

    [Header("�ö���� �ӵ� ����")]
    [SerializeField] float upSpeed;

    [Header("��� Ŭ�� ����")]
    [SerializeField] int countNumber;

    [SerializeField] int countBlock;
    

    [SerializeField] TouchBlock[] blocks;

    [SerializeField] private List<int> numbers = new List<int>();
    [SerializeField] private Vector3 preLocation;
    [SerializeField] private UnderGround underground;

    void Start()
    {
        ResetNumbers();
        numbers.Remove(numbers[13]);
        
    }



    public int GetNextNumber()
    {
        int randomNumber;

        do
        {
            randomNumber = Random.Range(0, 16); // 0~15 ������ ���� ���� ����
            Debug.Log(randomNumber);
        }
        while (!numbers.Contains(randomNumber)); // ����Ʈ�� ���� ���ڶ�� �ٽ� �̱�
        {
            numbers.Remove(randomNumber); // ����Ʈ���� ����
            countBlock++;
        }
        // ����Ʈ�� ����ٸ� �ٽ� �ʱ�ȭ
        if (numbers.Count == 0)
        {
            ResetNumbers();
        }

        if (countBlock >= 16)
        {
            Debug.Log("Under�ø���");
            countBlock = 0;
            underground.UpGround();
        }

        return randomNumber;
    }

    private void ResetNumbers()
    {
        numbers.Clear();
        for (int i = 0; i < 16; i++)
        {
            numbers.Add(i);
        }
    }


    IEnumerator MoveUp()
    {
        preLocation = blocks[countNumber].transform.position; //���� ��ġ ����
        Vector3 targetLocation = preLocation + Vector3.up;            //�̵� �ؾ��� ��ġ ����
        
        posUpTime = 0;

        while (posUpTime < checkTime)
        {
            posUpTime += Time.deltaTime / upSpeed;
            blocks[countNumber].transform.position = Vector3.Lerp(preLocation, targetLocation, posUpTime);
            yield return null;
        }
        blocks[countNumber].transform.position = targetLocation;
        Debug.Log("MoveUp" + blocks[countNumber].transform.position);
        Debug.Log("MoveUpPre" + preLocation);
    }

// Start is called before the first frame update
    public void SwapStart()
    {
        countNumber = GetNextNumber();
        StartCoroutine(MoveUp());
        blocks[countNumber].touchPossible = true;

        // ������� ���� ��ġ�� ������
    }

    public void PosChange()
    {
        Debug.Log("PosChange");
        blocks[countNumber].transform.position = preLocation;
    }

}

