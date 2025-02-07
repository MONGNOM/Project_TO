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

    [SerializeField] int countNumber;
    

    [SerializeField] TouchBlock[] blocks;

    [SerializeField] private List<int> numbers = new List<int>();
 

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

        numbers.Remove(randomNumber); // ����Ʈ���� ����

        // ����Ʈ�� ����ٸ� �ٽ� �ʱ�ȭ
        if (numbers.Count == 0)
        {
            ResetNumbers();
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
        Vector3 preLocation = blocks[countNumber].transform.position; //���� ��ġ ����
        Vector3 targetLocation = preLocation + Vector3.up;            //�̵� �ؾ��� ��ġ ����
        
        posUpTime = 0;

        while (posUpTime < checkTime)
        {
            posUpTime += Time.deltaTime / upSpeed;
            blocks[countNumber].transform.position = Vector3.Lerp(preLocation, targetLocation, posUpTime);
            yield return null;
        }
        blocks[countNumber].transform.position = targetLocation;

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
        //blocks[countNumber].transform.position = preLocation;
        Debug.Log("�� ��ġ" + blocks[countNumber].transform.position);
    }

}

